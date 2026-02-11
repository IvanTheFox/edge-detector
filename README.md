# Information
This program is designed to detect edges of an image. The program includes a GUI, that provides the following features:
- selecting an image from your computer for the program to analyze
- selecting an operator for the edge detection process
- toggling thresholding
- selecting single or double thresholding options
- displaying the resulting image
- saving the resulting image to your computer

# Development
## Action scenario
1. user selects an image, operator and thresholding
2. read the image 
3. convert the image to a *Bitmap* (rgba format) (ignore the alpha channel)
4. choose an operator (sobel or whatever)
5. iterate over each pixel => gradient magnitude map
	1. get the surrounding pixels (depending on the size of the operator)
	2. *for x and y axes and for each color* apply the operator to the slice of the image (convolution) => get 6 partial derivates for 3 colors and 2 axes
	3. sum the color derivatives for respective axes => get 2 partial derivatives for x and y axes
	4. calculate gradient magnitude (square root of sum of squares of partial derivates)
6. introduce thresholding (1) or no thresholding (2) => final image
	1. single (1) or double (2) thresholding
		1. Single threshold, where magnitude > threshold => edge
		2. 2 thresholds, where:
			1. magnitude < threshold1 => no edge
			2. threshold1 < magnitude < threshold2 => edge if an adjacent pixel is an edge
			3. magnitude > threshold2 => is edge
		3. convert binary matrix to image (*pure white or black*)
	2. convert number matrix to black and white image (*shades of grey*)
7. display the resulting image
## Possible / encountered problems
- (?) edge detection process is slow
- the resulting image is smaller in size than the original
- (?) pixel opacity not affecting edge detection