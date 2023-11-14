using System;
using System.Drawing;
using System.Numerics;

static class CollisionDetection
{
    static void Main(string[] args)
    {
        int selection_of_program = 1;

        Console.WriteLine("WELCOME TO THE COLLISION DETICTION PROGRAM\n");

        do
        {
            Console.WriteLine("How would you like to actualize the collision detiction?\n");
            Console.WriteLine("(By giving values as input = 1, Let the computer give examples = 0)\n");
            int selection_for_actualization = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            if (selection_for_actualization == 1)
            {

                Console.WriteLine("Which collision detiction you want to actualize?\n");
                Console.WriteLine("1) Point - Rectangle");
                Console.WriteLine("2) Point - Circle");
                Console.WriteLine("3) Rectangle - Rectangle");
                Console.WriteLine("4) Rectangle - Circle");
                Console.WriteLine("5) Circle - Circle");
                Console.WriteLine("6) Point - Globe");
                Console.WriteLine("7) Point - Quadrangular");
                Console.WriteLine("8) Point - Cylinder");
                Console.WriteLine("9) Cylinder - Cylinder");
                Console.WriteLine("10) Globe - Globe");
                Console.WriteLine("11) Globe - Cylinder");
                Console.WriteLine("12) Surface - Globe");
                Console.WriteLine("13) Surface - Quadrangular");
                Console.WriteLine("14) Surface - Cylinder");
                Console.WriteLine("15) Globe - Quadrangular");
                Console.WriteLine("16) Quadrangular - Quadrangular");

                int selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1) //point - rectangle
                {
                    //input
                    Console.WriteLine("Enter the x coordinate of the point:");
                    int pointX = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the y coordinate of the point:");
                    int pointY = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the x coordinate of the top-left corner of the rectangle:");
                    int rectX = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the y coordinate of the top-left corner of the rectangle:");
                    int rectY = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the width of the rectangle:");
                    int rectWidth = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the height of the rectangle:");
                    int rectHeight = int.Parse(Console.ReadLine());

                    //collision detection
                    bool isCollision = pointX >= rectX && pointX <= rectX + rectWidth &&
                                       pointY >= rectY && pointY <= rectY + rectHeight;

                    //output
                    if (isCollision)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 2) //point - circle
                {
                    //input
                    Console.WriteLine("Enter the x-coordinate of the point:");
                    double pointX = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the y-coordinate of the point:");
                    double pointY = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the radius of the circle:");
                    double radius = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the x-coordinate of the circle:");
                    double circleX = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the y-coordinate of the circle:");
                    double circleY = double.Parse(Console.ReadLine());

                    double distance = Math.Sqrt(Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2));

                    //output
                    if (distance <= radius)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 3) //rectangle - rectangle
                {
                    //input
                    Console.Write("Enter the x-coordinate of the top-left corner of the first rectangle: ");
                    int x1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter the y-coordinate of the top-left corner of the first rectangle: ");
                    int y1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter the width of the first rectangle: ");
                    int width1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter the height of the first rectangle: ");
                    int height1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter the x-coordinate of the top-left corner of the second rectangle: ");
                    int x2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter the y-coordinate of the top-left corner of the second rectangle: ");
                    int y2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter the width of the second rectangle: ");
                    int width2 = int.Parse(Console.ReadLine());
                    Console.Write("Enter the height of the second rectangle: ");
                    int height2 = int.Parse(Console.ReadLine());

                    //collision and output
                    if (x1 + width1 >= x2 && x1 <= x2 + width2 && y1 + height1 >= y2 && y1 <= y2 + height2)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 4) //rectangle - circle
                {
                    //input
                    Console.Write("Enter the x-coordinate of the center of the circle: ");
                    double circleX = double.Parse(Console.ReadLine());
                    Console.Write("Enter the y-coordinate of the center of the circle: ");
                    double circleY = double.Parse(Console.ReadLine());
                    Console.Write("Enter the radius of the circle: ");
                    double radius = double.Parse(Console.ReadLine());
                    Console.Write("Enter the x-coordinate of the top-left corner of the rectangle: ");
                    double rectX = double.Parse(Console.ReadLine());
                    Console.Write("Enter the y-coordinate of the top-left corner of the rectangle: ");
                    double rectY = double.Parse(Console.ReadLine());
                    Console.Write("Enter the width of the rectangle: ");
                    double rectWidth = double.Parse(Console.ReadLine());
                    Console.Write("Enter the height of the rectangle: ");
                    double rectHeight = double.Parse(Console.ReadLine());

                    //collision
                    double closestX = clamp(circleX, rectX, rectX + rectWidth);
                    double closestY = clamp(circleY, rectY, rectY + rectHeight);
                    double distanceX = circleX - closestX;
                    double distanceY = circleY - closestY;
                    double distanceSquared = distanceX * distanceX + distanceY * distanceY;
                    bool collides = distanceSquared < radius * radius;

                    //output
                    if (collides)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 5) //circle - circle
                {
                    double x1, y1, r1, x2, y2, r2;

                    Console.WriteLine("Enter the x-coordinate, y-coordinate, and radius of circle 1:");
                    x1 = double.Parse(Console.ReadLine());
                    y1 = double.Parse(Console.ReadLine());
                    r1 = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the x-coordinate, y-coordinate, and radius of circle 2:");
                    x2 = double.Parse(Console.ReadLine());
                    y2 = double.Parse(Console.ReadLine());
                    r2 = double.Parse(Console.ReadLine());

                    double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

                    if (distance <= r1 + r2)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 6) //point - globe
                {
                    //input
                    Console.Write("Enter the x coordinate of the point: ");
                    double pointX = double.Parse(Console.ReadLine());
                    Console.Write("Enter the y coordinate of the point: ");
                    double pointY = double.Parse(Console.ReadLine());
                    Console.Write("Enter the z coordinate of the point: ");
                    double pointZ = double.Parse(Console.ReadLine());
                    Console.Write("Enter the x coordinate of the sphere: ");
                    double sphereX = double.Parse(Console.ReadLine());
                    Console.Write("Enter the y coordinate of the sphere: ");
                    double sphereY = double.Parse(Console.ReadLine());
                    Console.Write("Enter the z coordinate of the sphere: ");
                    double sphereZ = double.Parse(Console.ReadLine());
                    Console.Write("Enter the radius of the sphere: ");
                    double sphereRadius = double.Parse(Console.ReadLine());

                    //calculations
                    double distance = Math.Sqrt(Math.Pow(pointX - sphereX, 2) + Math.Pow(pointY - sphereY, 2) + Math.Pow(pointZ - sphereZ, 2));

                    //collusion and output
                    if (distance <= sphereRadius)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 7) //point - quadrangular
                {
                    //input
                    Console.WriteLine("Enter point coordinates (x,y):");
                    string pointInput = Console.ReadLine();
                    double pointX = double.Parse(pointInput.Split(',')[0]);
                    double pointY = double.Parse(pointInput.Split(',')[1]);

                    Console.WriteLine("Enter quadrilateral coordinates (x1,y1,x2,y2,x3,y3,x4,y4):");
                    string quadInput = Console.ReadLine();
                    double[] quadCoords = Array.ConvertAll(quadInput.Split(','), double.Parse);

                    //calculation
                    double[][] edges = new double[4][];
                    edges[0] = new double[] { quadCoords[0], quadCoords[1], quadCoords[2], quadCoords[3] };
                    edges[1] = new double[] { quadCoords[2], quadCoords[3], quadCoords[4], quadCoords[5] };
                    edges[2] = new double[] { quadCoords[4], quadCoords[5], quadCoords[6], quadCoords[7] };
                    edges[3] = new double[] { quadCoords[6], quadCoords[7], quadCoords[0], quadCoords[1] };

                    //check
                    bool collisionDetected = false;
                    for (int i = 0; i < 4; i++)
                    {
                        double[] edge = edges[i];
                        double edgeX1 = edge[0];
                        double edgeY1 = edge[1];
                        double edgeX2 = edge[2];
                        double edgeY2 = edge[3];

                        //calculations
                        double d = Math.Abs((pointY - edgeY1) * (edgeX2 - edgeX1) - (pointX - edgeX1) * (edgeY2 - edgeY1)) /
                                   Math.Sqrt(Math.Pow(edgeY2 - edgeY1, 2) + Math.Pow(edgeX2 - edgeX1, 2));

                        //check
                        if (d == 0)
                        {
                            collisionDetected = true;
                            break;
                        }
                    }

                    //output
                    if (collisionDetected)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 8) //point - cylinder
                {
                    //input
                    Console.Write("Enter the x-coordinate of the point: ");
                    double pointX = double.Parse(Console.ReadLine());

                    Console.Write("Enter the y-coordinate of the point: ");
                    double pointY = double.Parse(Console.ReadLine());

                    Console.Write("Enter the z-coordinate of the point: ");
                    double pointZ = double.Parse(Console.ReadLine());

                    Console.Write("Enter the radius of the cylinder: ");
                    double radius = double.Parse(Console.ReadLine());

                    Console.Write("Enter the height of the cylinder: ");
                    double height = double.Parse(Console.ReadLine());

                    Console.Write("Enter the x-coordinate of the cylinder's center: ");
                    double cylinderX = double.Parse(Console.ReadLine());

                    Console.Write("Enter the y-coordinate of the cylinder's center: ");
                    double cylinderY = double.Parse(Console.ReadLine());

                    Console.Write("Enter the z-coordinate of the cylinder's center: ");
                    double cylinderZ = double.Parse(Console.ReadLine());

                    //calculations
                    double distance = Math.Sqrt(Math.Pow(pointX - cylinderX, 2) + Math.Pow(pointY - cylinderY, 2) + Math.Pow(pointZ - cylinderZ, 2));

                    //check and output
                    if (distance <= radius && pointY >= cylinderY && pointY <= cylinderY + height)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 9) //cylinder - cylinder
                {
                    //input
                    Console.WriteLine("Enter radius, height, and location of first cylinder (x, y, z) separated by spaces:");
                    string[] input1 = Console.ReadLine().Split(' ');
                    double radius1 = double.Parse(input1[0]);
                    double height1 = double.Parse(input1[1]);
                    double x1 = double.Parse(input1[2]);
                    double y1 = double.Parse(input1[3]);
                    double z1 = double.Parse(input1[4]);

                    Console.WriteLine("Enter radius, height, and location of second cylinder (x, y, z) separated by spaces:");
                    string[] input2 = Console.ReadLine().Split(' ');
                    double radius2 = double.Parse(input2[0]);
                    double height2 = double.Parse(input2[1]);
                    double x2 = double.Parse(input2[2]);
                    double y2 = double.Parse(input2[3]);
                    double z2 = double.Parse(input2[4]);

                    //calculations
                    double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));

                    //check and output
                    if (distance <= radius1 + radius2 && Math.Abs(z2 - z1) <= Math.Max(height1, height2))
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 10) //globe - globe
                {
                    //input
                    Console.Write("Enter the radius of sphere 1: ");
                    double r1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the x-coordinate of sphere 1: ");
                    double x1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the y-coordinate of sphere 1: ");
                    double y1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the z-coordinate of sphere 1: ");
                    double z1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the radius of sphere 2: ");
                    double r2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the x-coordinate of sphere 2: ");
                    double x2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the y-coordinate of sphere 2: ");
                    double y2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the z-coordinate of sphere 2: ");
                    double z2 = Convert.ToDouble(Console.ReadLine());

                    //calculations
                    double dx = x2 - x1;
                    double dy = y2 - y1;
                    double dz = z2 - z1;
                    double distance = Math.Sqrt(dx * dx + dy * dy + dz * dz);

                    //collision
                    if (distance < r1 + r2)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 11) //globe - cylinder
                {
                    //input
                    Console.WriteLine("Enter the radius and location of the sphere:");
                    float sphereRadius = float.Parse(Console.ReadLine());
                    float[] sphereLocation = new float[3];
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write($"Enter sphere location coordinate {i + 1}: ");
                        sphereLocation[i] = float.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("\nEnter the radius, height, and location of the cylinder:");
                    float cylinderRadius = float.Parse(Console.ReadLine());
                    float cylinderHeight = float.Parse(Console.ReadLine());
                    float[] cylinderLocation = new float[3];
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write($"Enter cylinder location coordinate {i + 1}: ");
                        cylinderLocation[i] = float.Parse(Console.ReadLine());
                    }

                    //calculations
                    float dx = sphereLocation[0] - cylinderLocation[0];
                    float dy = sphereLocation[1] - cylinderLocation[1];
                    float dz = sphereLocation[2] - cylinderLocation[2];
                    float distance = (float)Math.Sqrt(dx * dx + dz * dz);

                    //check
                    bool isColliding = distance < cylinderRadius + sphereRadius && Math.Abs(dy) < cylinderHeight / 2;

                    //collision
                    if (isColliding)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 12) //surface - globe
                {
                    //input
                    Console.Write("Enter sphere radius: ");
                    double sphereRadius = double.Parse(Console.ReadLine());

                    Console.Write("Enter sphere location (x y z): ");
                    string[] sphereLocationInput = Console.ReadLine().Split();
                    double sphereX = double.Parse(sphereLocationInput[0]);
                    double sphereY = double.Parse(sphereLocationInput[1]);
                    double sphereZ = double.Parse(sphereLocationInput[2]);

                    Console.Write("Enter surface location (x y z): ");
                    string[] surfaceLocationInput = Console.ReadLine().Split();
                    double surfaceX = double.Parse(surfaceLocationInput[0]);
                    double surfaceY = double.Parse(surfaceLocationInput[1]);
                    double surfaceZ = double.Parse(surfaceLocationInput[2]);

                    Console.Write("Enter surface radius: ");
                    double surfaceRadius = double.Parse(Console.ReadLine());

                    //calculations
                    double distance = Math.Sqrt(Math.Pow(sphereX - surfaceX, 2) + Math.Pow(sphereY - surfaceY, 2) + Math.Pow(sphereZ - surfaceZ, 2));

                    //check
                    if (distance <= sphereRadius + surfaceRadius)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 13) //surface - quadrangular
                {
                    //input
                    Console.WriteLine("Enter the location and dimensions of the quadrangular surface:");
                    Console.Write("X: ");
                    double x1 = double.Parse(Console.ReadLine());
                    Console.Write("Y: ");
                    double y1 = double.Parse(Console.ReadLine());
                    Console.Write("Z: ");
                    double z1 = double.Parse(Console.ReadLine());
                    Console.Write("Width: ");
                    double width1 = double.Parse(Console.ReadLine());
                    Console.Write("Height: ");
                    double height1 = double.Parse(Console.ReadLine());
                    Console.Write("Depth: ");
                    double depth1 = double.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter the location and dimensions of the surface to check:");
                    Console.Write("X: ");
                    double x2 = double.Parse(Console.ReadLine());
                    Console.Write("Y: ");
                    double y2 = double.Parse(Console.ReadLine());
                    Console.Write("Z: ");
                    double z2 = double.Parse(Console.ReadLine());
                    Console.Write("Width: ");
                    double width2 = double.Parse(Console.ReadLine());
                    Console.Write("Height: ");
                    double height2 = double.Parse(Console.ReadLine());
                    Console.Write("Depth: ");
                    double depth2 = double.Parse(Console.ReadLine());

                    //check
                    if (x1 < x2 + width2 &&
                        x1 + width1 > x2 &&
                        y1 < y2 + height2 &&
                        y1 + height1 > y2 &&
                        z1 < z2 + depth2 &&
                        z1 + depth1 > z2)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 14) //surface - cylinder
                {
                    //input
                    Console.Write("Enter cylinder radius: ");
                    double radius = double.Parse(Console.ReadLine());
                    Console.Write("Enter cylinder height: ");
                    double height = double.Parse(Console.ReadLine());
                    Console.Write("Enter cylinder location (x,y,z): ");
                    string[] locCylinder = Console.ReadLine().Split(',');
                    double xCylinder = double.Parse(locCylinder[0]);
                    double yCylinder = double.Parse(locCylinder[1]);
                    double zCylinder = double.Parse(locCylinder[2]);

                    Console.Write("Enter surface location (x,y,z): ");
                    string[] locSurface = Console.ReadLine().Split(',');
                    double xSurface = double.Parse(locSurface[0]);
                    double ySurface = double.Parse(locSurface[1]);
                    double zSurface = double.Parse(locSurface[2]);

                    //calculations
                    double distance = Math.Sqrt(Math.Pow(xCylinder - xSurface, 2) +
                                                Math.Pow(yCylinder - ySurface, 2) +
                                                Math.Pow(zCylinder - zSurface, 2));

                    //calculations
                    double minDistance = radius;

                    if (distance <= minDistance)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 15) //globe - quadrangular
                {
                    //input
                    Console.Write("Enter sphere radius: ");
                    double sphereRadius = double.Parse(Console.ReadLine());
                    Console.Write("Enter sphere location (x, y, z): ");
                    double sphereX = double.Parse(Console.ReadLine());
                    double sphereY = double.Parse(Console.ReadLine());
                    double sphereZ = double.Parse(Console.ReadLine());
                    Console.Write("Enter quadrilateral depth: ");
                    double quadDepth = double.Parse(Console.ReadLine());
                    Console.Write("Enter quadrilateral location (x, y, z): ");
                    double quadX = double.Parse(Console.ReadLine());
                    double quadY = double.Parse(Console.ReadLine());
                    double quadZ = double.Parse(Console.ReadLine());

                    //check
                    bool collision = false;
                    if (sphereX + sphereRadius >= quadX && sphereX - sphereRadius <= quadX + quadDepth
                        && sphereY + sphereRadius >= quadY && sphereY - sphereRadius <= quadY + quadDepth
                        && sphereZ + sphereRadius >= quadZ && sphereZ - sphereRadius <= quadZ + quadDepth)
                    {
                        collision = true;
                    }

                    //collision
                    if (collision)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

                else if (selection == 16) //quadrangular - quadrangular
                {
                    //input
                    Console.Write("Enter the x-coordinate of the first shape: ");
                    double x1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter the y-coordinate of the first shape: ");
                    double y1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter the width of the first shape: ");
                    double width1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter the height of the first shape: ");
                    double height1 = double.Parse(Console.ReadLine());

                    Console.Write("Enter the x-coordinate of the second shape: ");
                    double x2 = double.Parse(Console.ReadLine());
                    Console.Write("Enter the y-coordinate of the second shape: ");
                    double y2 = double.Parse(Console.ReadLine());
                    Console.Write("Enter the width of the second shape: ");
                    double width2 = double.Parse(Console.ReadLine());
                    Console.Write("Enter the height of the second shape: ");
                    double height2 = double.Parse(Console.ReadLine());

                    //check
                    bool areColliding =
                        x1 < x2 + width2 &&
                        x1 + width1 > x2 &&
                        y1 < y2 + height2 &&
                        y1 + height1 > y2;

                    //output
                    if (areColliding)
                    {
                        Console.WriteLine("There is a collision.");
                    }

                    else
                    {
                        Console.WriteLine("There is no collision.");
                    }

                }

            }

            else if (selection_for_actualization == 0)
            {
                //define
                Point point0 = new Point(5, 5);
                Rectangle rectangle0 = new Rectangle(0, 0, 10, 10);

                //check
                bool collisionDetected = rectangle0.Contains(point0);

                //output
                Console.WriteLine("Point(5, 5), Rectangle(0, 0, 10, 10)\n");
                Console.WriteLine(collisionDetected ? "Collision detected\n" : "No collision detected\n");

                Circle circle0 = new Circle(5.0f, 5.0f, 3.0f);

                //define
                Point point1 = new Point(7, 7);

                Console.WriteLine("Point(7, 7), Circle(5, 5, 3)\n");

                //check
                if (circle0.Contains(point1))
                {
                    Console.WriteLine("The point is inside the circle.\n");
                }

                else if (Math.Sqrt(Math.Pow(point1.X - circle0.CenterX, 2) + Math.Pow(point1.Y - circle0.CenterY, 2)) == circle0.Radius)
                {
                    Console.WriteLine("The point is on the circle.\n");
                }

                else
                {
                    Console.WriteLine("The point is outside the circle.\n");
                }

                Rectangle rectangle1 = new Rectangle(0, 0, 50, 50);
                Rectangle rectangle2 = new Rectangle(25, 25, 50, 50);

                Console.WriteLine("Rectangle1(0, 0, 50, 50), Rectangle(25, 25, 50, 50)\n");

                if (rectangle1.CollidesWith(rectangle2))
                {
                    Console.WriteLine("Collision detected!\n");
                }

                else
                {
                    Console.WriteLine("No collision detected.\n");
                }

                Circle circle1 = new Circle(5.0f, 5.0f, 2.0f);
                Rectangle rectangle3 = new Rectangle(2.0f, 2.0f, 4.0f, 4.0f);

                Console.WriteLine("Circle(5, 5, 2), Rectangle(2, 2, 4, 4)\n");

                if (rectangle3.CollidesWith(circle1))
                {
                    Console.WriteLine("The rectangle and circle intersect.\n");
                }

                else
                {
                    Console.WriteLine("The rectangle and circle do not intersect.\n");
                }

                Circle circle3 = new Circle(0, 0, 1);
                Circle circle4 = new Circle(2, 0, 1);

                Console.WriteLine("Circle(0, 0, 1), Circle(2, 0, 1)\n");

                if (circle3.CollidesWith(circle4))
                {
                    Console.WriteLine("The circles collide!\n");
                }

                else
                {
                    Console.WriteLine("The circles do not collide.\n");
                }

                Point point2 = new Point(1.0f, 2.0f, 3.0f);
                Sphere sphere0 = new Sphere(new Point(0, 0, 0), 5);

                bool collision = sphere0.CollidesWith(point2);

                Console.WriteLine("Point(1, 2, 3), Sphere(0, 0, 0, 5)\n");

                if (collision)
                {
                    Console.WriteLine("There is a collition!\n");
                }

                else
                {
                    Console.WriteLine("There is no collition!\n");
                }

                Point p = new Point(2, 3);
                Quadrilateral q = new Quadrilateral(new Point(1, 1), new Point(3, 1), new Point(3, 3), new Point(1, 3));

                Console.WriteLine("Point(2, 3); Quadrilateral(1, 1), (3, 1), (3, 3), (1, 3)\n");

                if (q.Contains(p))
                {
                    Console.WriteLine("The point is inside the quadrilateral.\n");
                }

                else
                {
                    Console.WriteLine("The point is outside the quadrilateral.\n");
                }

                Point point = new Point(0, 0, 0);
                Cylinder cylinder = new Cylinder(0, 0, 5, 1, 2);
                bool collision1 = cylinder.CheckCollision(point);

                Console.WriteLine("Point(0, 0, 0), Cylinder(0, 0, 5, 1, 2)\n");
                Console.WriteLine("Collision: " + collision1);

                Cylinder cylinder1 = new Cylinder(0, 0, 0, 1, 2);
                Cylinder cylinder2 = new Cylinder(3, 0, 0, 1, 2);
                Console.WriteLine("Cylinder(0, 0, 0, 1, 2), Cylinder(3, 0, 0, 1, 2)\n");
                bool collides2 = cylinder1.CollidesWith(cylinder2);

                Console.WriteLine("Collision: " + collides2);

                Sphere s1 = new Sphere(0, 0, 0, 1);
                Sphere s2 = new Sphere(2, 0, 0, 1);

                Console.WriteLine("Sphere(0, 0, 0, 1), Sphere(2, 0, 0, 1)\n");

                if (s1.collidesWith(s2))
                {
                    Console.WriteLine("The spheres collide!\n");
                }

                else
                {
                    Console.WriteLine("The spheres don't collide.\n");
                }

                Sphere sphere = new Sphere(2, 0, 0, 0);
                Cylinder cylinder3 = new Cylinder(1, 5, 0, 0, 0);
                Console.WriteLine("Sphere(2, 0, 0, 0), Cylinder(1, 5, 0, 0, 0)\n");

                if (CheckSphereCylinderCollision(sphere, cylinder3))
                {
                    Console.WriteLine("The sphere and cylinder intersect.\n");
                }

                else
                {
                    Console.WriteLine("The sphere and cylinder do not intersect.\n");
                }

                Sphere sphere5 = new Sphere(1.0f, new Vector3(0.0f, 0.0f, 0.0f));
                Surface surface = new Surface(new Vector3(0.0f, 1.0f, 0.0f), 0.0f);
                Console.WriteLine("Sphere(1, 0, 0, 0), Surface(0, 1, 0)\n");


            }

            else
            {
                Console.WriteLine("You have entered the wrong number value.\n");
            }

            Console.WriteLine("Do you want the program to continue working? (Yes 1, No 0)\n");

            selection_of_program = Convert.ToInt32(Console.ReadLine());

        } while (selection_of_program == 1);

        static double clamp(double value, double min, double max)
        {
            return Math.Max(Math.Min(value, max), min);
        }


    }

    class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public float Z { get; set; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Point(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }

    class Rectangle
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Rectangle(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public bool Contains(Point point)
        {
            return point.X >= X && point.X <= X + Width && point.Y >= Y && point.Y <= Y + Height;
        }

        public bool CollidesWith(Rectangle other)
        {
            if (this.X + this.Width < other.X || other.X + other.Width < this.X)
            {
                return false;
            }

            if (this.Y + this.Height < other.Y || other.Y + other.Height < this.Y)
            {
                return false;
            }

            return true;
        }

        public bool CollidesWith(Circle circle)
        {
            float distX = (float)Math.Abs(circle.CenterX - this.X - this.Width / 2);
            float distY = (float)Math.Abs(circle.CenterY - this.Y - this.Height / 2);

            if (distX > (this.Width / 2 + circle.Radius)) { return false; }
            if (distY > (this.Height / 2 + circle.Radius)) { return false; }

            if (distX <= (this.Width / 2)) { return true; }
            if (distY <= (this.Height / 2)) { return true; }

            float dx = distX - this.Width / 2;
            float dy = distY - this.Height / 2;
            return (dx * dx + dy * dy <= (circle.Radius * circle.Radius));
        }

    }

    class Circle
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Radius { get; set; }

        public Circle(float x, float y, float radius)
        {
            this.CenterX = x;
            this.CenterY = y;
            this.Radius = radius;
        }

        public bool Contains(Point point)
        {
            double distance = Math.Sqrt(Math.Pow(point.X - CenterX, 2) + Math.Pow(point.Y - CenterY, 2));
            return distance <= Radius;
        }

        public bool CollidesWith(Rectangle rect)
        {
            return rect.CollidesWith(this);
        }

        public bool CollidesWith(Circle other)
        {
            double dx = this.CenterX - other.CenterX;
            double dy = this.CenterY - other.CenterY;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            return distance < this.Radius + other.Radius;
        }

    }

    class Sphere
    {
        public Point center;
        public float radius;

        public Sphere(Point center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public float x, y, z, r;

        public Sphere(float x, float y, float z, float r)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.r = r;
        }

        public bool collidesWith(Sphere other)
        {
            float dx = x - other.x;
            float dy = y - other.y;
            float dz = z - other.z;
            float d = (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
            return d <= r + other.r;
        }

        public bool CollidesWith(Point point)
        {
            float distance = (float)Math.Sqrt(Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2) + Math.Pow(point.Z - center.Z, 2));
            return distance <= radius;
        }

        public float radius1;
        public Vector3 position;

        public Sphere(float radius, Vector3 position)
        {
            this.radius1 = radius;
            this.position = position;
        }
    }

    class Quadrilateral
    {
        private Point[] vertices = new Point[4];

        public Quadrilateral(Point a, Point b, Point c, Point d)
        {
            vertices[0] = a;
            vertices[1] = b;
            vertices[2] = c;
            vertices[3] = d;
        }

        public bool Contains(Point p)
        {
            bool inside = false;

            for (int i = 0, j = vertices.Length - 1; i < vertices.Length; j = i++)
            {
                if (((vertices[i].Y > p.Y) != (vertices[j].Y > p.Y)) &&
                     (p.X < (vertices[j].X - vertices[i].X) * (p.Y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) + vertices[i].X))
                {
                    inside = !inside;
                }
            }

            return inside;
        }
    }

    class Cylinder
    {
        public float x;
        public float y;
        public float z;
        public float radius;
        public float height;

        public Cylinder(float x, float y, float z, float radius, float height)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.radius = radius;
            this.height = height;
        }

        public bool CheckCollision(Point point)
        {
            //calculation
            float distanceX = point.X - x;
            float distanceY = point.Y - y;
            float distanceZ = point.Z - z;
            float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY + distanceZ * distanceZ);

            //check
            if (distance < radius)
            {
                return true;
            }

            //check
            if (point.Z > z - height / 2 && point.Z < z + height / 2)
            {
                //calculation
                float horizontalDistance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                //check
                if (horizontalDistance < radius)
                {
                    return true;
                }
            }

            //check
            return false;
        }

        public bool CollidesWith(Cylinder other)
        {
            float dx = this.x - other.x;
            float dy = this.y - other.y;
            float dz = this.z - other.z;
            float distanceSquared = dx * dx + dy * dy + dz * dz;
            float radiusSum = this.radius + other.radius;

            if (distanceSquared > radiusSum * radiusSum)
                return false;

            float heightSum = this.height + other.height;
            if (Math.Abs(dz) > heightSum / 2)
                return false;

            float radiusDiff = Math.Abs(this.radius - other.radius);

            if (radiusDiff == 0)
            {
                float minH1 = this.y - this.height / 2;
                float maxH1 = this.y + this.height / 2;
                float minH2 = other.y - other.height / 2;
                float maxH2 = other.y + other.height / 2;
                return (maxH1 >= minH2 && maxH2 >= minH1);
            }

            else
            {
                float minR = Math.Min(this.radius, other.radius);
                float maxR = Math.Max(this.radius, other.radius);
                float minH = Math.Min(this.height, other.height);
                float maxH = Math.Max(this.height, other.height);

                //check
                float baseDistanceSquared = dx * dx + dy * dy;
                if (baseDistanceSquared < maxR * maxR)
                    return true;

                //check
                float topDistanceSquared = (dx * dx + dy * dy) + (dz - this.height + other.height) * (dz - this.height + other.height);
                if (topDistanceSquared < maxR * maxR)
                    return true;

                //check
                float slope = (maxR - minR) / maxH;
                float intersectionH = (slope * dz + minR) * slope;
                if (Math.Abs(dz) <= intersectionH && intersectionH <= minH)
                    return true;

                return false;
            }
        }

    }

    static bool CheckSphereCylinderCollision(Sphere sphere, Cylinder cylinder)
    {
        //check
        if (sphere.x + sphere.radius < cylinder.x - cylinder.radius ||
            sphere.x - sphere.radius > cylinder.x + cylinder.radius ||
            sphere.y + sphere.radius < cylinder.y ||
            sphere.y - sphere.radius > cylinder.y + cylinder.height ||
            sphere.z + sphere.radius < cylinder.z - cylinder.radius ||
            sphere.z - sphere.radius > cylinder.z + cylinder.radius)
        {
            return false;
        }

        if (sphere.x - cylinder.x >= 0 && sphere.x - cylinder.x <= cylinder.radius &&
            sphere.y - cylinder.y >= 0 && sphere.y - cylinder.y <= cylinder.height &&
            sphere.z - cylinder.z >= 0 && sphere.z - cylinder.z <= cylinder.radius)
        {
            return true;
        }

        double distFromTopCap = sphere.y - (cylinder.y + cylinder.height);
        double distFromBottomCap = cylinder.y - sphere.y;
        if (distFromTopCap * distFromTopCap + sphere.radius * sphere.radius <= cylinder.radius * cylinder.radius ||
            distFromBottomCap * distFromBottomCap + sphere.radius * sphere.radius <= cylinder.radius * cylinder.radius)
        {
            return true;
        }

        double dx = sphere.x - cylinder.x;
        double dz = sphere.z - cylinder.z;
        if (dx * dx + dz * dz <= cylinder.radius * cylinder.radius)
        {
            return true;
        }

        return false;
    }

    class Surface
    {
        public Vector3 normal;
        public float distance;

        public Surface(Vector3 normal, float distance)
        {
            this.normal = normal;
            this.distance = distance;
        }
    }

    class Vector3
    {
        public float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }

}