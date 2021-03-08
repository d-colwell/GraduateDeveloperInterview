# CorpCorp Box Decisioning Algoritm
## Our Objective
We here at Corpcorp are very concerned with Boxes. As a reputable brand, and purveyor of fine rectangles, we are looking to automate the process of determining which are the best. People often send us files full of boxes, and we are then responsible for chosing the best boxes out of this file. Your objective is to build us an algorithm that searches through the boxes that people send us, and only yields the finest of them.

## How do we choose the best boxes? 
Boxes come in CSV files, with 6 columns and a single header record. The columns are the Index, 2 integer coordinates (`X,Y`), 2 integer dimensions (`Width,Height`), and one decimal value (`Rank`) (between 0 and 1) representing the Rank. Rank is a representation of how important the box is, with a larger value (e.g 0.8) being more important than a smaller value (e.g. 0.4). There may be an arbitrarily large number of boxes in the file.

The X and Y coordinate refer to the top left corner of the box.

An example of a box file would look like this:
| Index | X | Y | Width | Height | Rank |
|----|----|----|----|----|----|
| 1 | 2 | 2 | 4 | 3 | 0.6 |
| 2 | 3 | 9 | 12 | 8 | 0.9 |


The first item would give a box that looks like this:


<img src="./Images/box-example.png" width="600px"/>

The problem is that some of these boxes overlap.
We want to minimise the number of boxes by suppressing some of them. 
Each boxes has a Rank which denotes how important it is. 
Higher rank values supercede lower values.

In order to determine which rectangles will be suppressed, we will use a technique called the Jaqard Index.
The formula for the Jaqard index is `(Intersecting area of the rectangles) divided by (Union of the area of the rectangles)`

<img src="./Images/jaqard.png" width="600px" />

If the Intersection over Union (Jaccard Index) is greater than `0.4` (called the Jaqard index threshold), then the box with the lower Rank will be ignored.

In order to make our algorithm faster, we also have a Rank Threshold. Boxes with a Rank lower than `0.5` will be ignored entirely! 

<img src="./Images/poof.gif" width="200px"/>

## What outcome do we get
We want a list of all boxes in a file that *do not* get suppressed by the above formula

## What do we want you to do?

### Task 1:
A solution exists in [the src directory](./src). This solution contains a sample [box file](./src/BoxCorp/BoxCorp.App/boxes.csv).  
Implement your solution in the `BoxFilter.cs` file.
There are a suite of tests, which will tell you when your solution is correct.
You will be judged based on:
1. Accuracy of the algorithm
2. Code Cleanliness
3. Performance of the code against a benchmark

As a guide, a correct solution will yield 2510 boxes remaining after the algorithm is complete

### Task 2:
Extend the unit tests to cover some of the additional scenarios. An example is below:

![](./Images/acceptance.png)
