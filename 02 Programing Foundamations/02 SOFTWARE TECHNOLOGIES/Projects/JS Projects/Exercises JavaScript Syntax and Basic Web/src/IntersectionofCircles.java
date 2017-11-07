import java.util.Arrays;
import java.util.Scanner;

public class IntersectionofCircles {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Circle firstCircle = ReadCircle(scanner.nextLine());
        Circle secondCircle = ReadCircle(scanner.nextLine());
        if (Intersect(firstCircle, secondCircle)) System.out.println("Yes");
        else System.out.println("No");

    }

    private static boolean Intersect(Circle c1, Circle c2) {
        double distance = CalculateDistanceBetweenCenters(c1.Center, c2.Center);
        if (distance <= c1.Radius + c2.Radius) return true;
        else return false;
    }

    private static double CalculateDistanceBetweenCenters(Point M, Point N) {
        double result = Math.sqrt(Math.pow(M.X - N.X, 2) + Math.pow(M.Y - N.Y, 2));
        return result;
    }

    private static Circle ReadCircle(String text) {


        int[] input = Arrays
        .stream(text.split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        Point center = new Point();
        center.X = input[0];
        center.Y = input[1];
        Circle currentCircle = new Circle();
        currentCircle.Radius = input[2];
        currentCircle.Center = center;
        return currentCircle;
    }

    public static class Circle {

        public Integer Radius;
        public Point Center;

        public Circle() {
        }

        public Circle(Integer radius, Point center) {
            Radius = radius;
            Center = center;
        }

        public Integer getRadius() {
            return Radius;
        }

        public void setRadius(Integer radius) {
            Radius = radius;
        }

        public Point getCenter() {
            return Center;
        }

        public void setCenter(Point center) {
            Center = center;
        }
    }

    public  static class Point {
       public Integer X;
        public Integer Y;

        public Point() {
        }

        public Point(Integer x, Integer y) {
            X = x;
            Y = y;
        }

        public Integer getX() {
            return X;
        }

        public void setX(Integer x) {
            X = x;
        }

        public Integer getY() {
            return Y;
        }

        public void setY(Integer y) {
            Y = y;
        }
    }
}
