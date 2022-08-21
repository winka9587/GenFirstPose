//#include <opencv2/opencv.hpp>
#include <opencv2/core.hpp>
#include <opencv2/highgui.hpp>
#include<iostream>
#include <time.h>
#include <fstream>
#include <queue>
#include <vector>

#include <algorithm>
#include <sstream>
#include <string>
#include <map>

using namespace cv;
using namespace std;
// Checks if a matrix is a valid rotation matrix.
bool isRotationMatrix(cv::Mat& R)
{
	cv::Mat Rt;
	transpose(R, Rt);
	cv::Mat shouldBeIdentity = Rt * R;
	cv::Mat I = cv::Mat::eye(3, 3, shouldBeIdentity.type());
	std::cout << norm(I, shouldBeIdentity) << std::endl;
	return  norm(I, shouldBeIdentity) < 1e-3;

}

cv::Mat eulerAnglesToRotationMatrix_RyRxRz(cv::Vec3f& theta)
{
	// Calculate rotation about x axis
	cv::Mat R_x = (cv::Mat_<float>(3, 3) <<
		1, 0, 0,
		0, cos(theta[0]), -sin(theta[0]),
		0, sin(theta[0]), cos(theta[0])
		);

	// Calculate rotation about y axis
	cv::Mat R_y = (cv::Mat_<float>(3, 3) <<
		cos(theta[1]), 0, sin(theta[1]),
		0, 1, 0,
		-sin(theta[1]), 0, cos(theta[1])
		);

	// Calculate rotation about z axis
	cv::Mat R_z = (cv::Mat_<float>(3, 3) <<
		cos(theta[2]), -sin(theta[2]), 0,
		sin(theta[2]), cos(theta[2]), 0,
		0, 0, 1);

	// Combined rotation matrix
	cv::Mat R = R_y * R_x * R_z;

	return R;

}


cv::Vec3f rotationMatrixToEulerAngles(cv::Mat& R)
{

	assert(isRotationMatrix(R));

	float sy = sqrt(R.at<float>(0, 0) * R.at<float>(0, 0) + R.at<float>(1, 0) * R.at<float>(1, 0));

	bool singular = sy < 1e-6; // If

	float x, y, z;
	if (!singular)
	{
		x = atan2(R.at<float>(2, 1), R.at<float>(2, 2));
		y = atan2(-R.at<float>(2, 0), sy);
		z = atan2(R.at<float>(1, 0), R.at<float>(0, 0));
	}
	else
	{
		x = atan2(-R.at<float>(1, 2), R.at<float>(1, 1));
		y = atan2(-R.at<float>(2, 0), sy);
		z = 0;
	}


	return cv::Vec3f(x, y, z);
}


int main()
{
	// Unity中参数变换到RBOT中
	Vec3f trans = { 9.433716,-82.30801,910.3345 };
	Vec3f eluer = { -111.029,174.708,17.39899 };


	trans[1] = -trans[1];
	eluer = eluer / 180 * CV_PI;
	cv::Mat R_L = cv::Mat::eye(3, 3, CV_32FC1);
	R_L.ptr<float>(1)[1] = -1;
	cv::Mat R_R = cv::Mat::eye(3, 3, CV_32FC1);
	R_R.ptr<float>(0)[0] = -1;

	Mat R_u = eulerAnglesToRotationMatrix_RyRxRz(eluer);
	Mat R = R_L.inv() * R_u * R_R.inv();
	
	Vec3f e = rotationMatrixToEulerAngles(R) * 180 / CV_PI;
	cout <<"R:\n"<< R << endl;

	cout <<"T:\n"<< trans << endl;
	cout <<"Euler:\n"<< e << endl;

	cout << "copy this：" << endl;
	cout << endl;
	cout << R.at<float>(0, 0) << "," << R.at<float>(0, 1) << "," << R.at<float>(0, 2) << "," << trans(0) << "," << endl;
	cout << R.at<float>(1, 0) << "," << R.at<float>(1, 1) << "," << R.at<float>(1, 2) << "," << trans(1) << "," << endl;
	cout << R.at<float>(2, 0) << "," << R.at<float>(2, 1) << "," << R.at<float>(2, 2) << "," << trans(2) << "," << endl;
	cout << "0,0,0,1" << endl;

	system("pause");
	return 0;
}