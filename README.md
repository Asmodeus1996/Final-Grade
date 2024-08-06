The University Grade Management System is a C# console application designed to manage student grades across different universities. The application allows users to:

Select a university from a list of available universities.
Enter grades for each class (4 grades per class).
Calculate average grades and final marks for each class.
Determine if the student passes or fails based on their grades.
Features
University Selection: Choose from three universities:

Software Development University
Medicine University
Sociological University
Class Management: Each university has a predefined set of classes.

Grade Validation: Grades must be between 1 and 5. Invalid grades prompt an error.

Average Grade Calculation: Average grades are calculated for each class and the overall performance.

Pass/Fail Determination: Students fail if any class has an average grade of exactly 1 or if any class's final mark is "Insufficient."

Grade Classification: Grades are classified as:

Insufficient (average < 1)
Sufficient (average >= 1 and < 2)
Good (average >= 2 and < 3)
Very Good (average >= 3 and < 4)
Excellent (average >= 4 and <= 5)
