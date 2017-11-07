import java.util.Scanner;

public class SumNIntegers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int number = Integer.parseInt(scanner.nextLine());
        int sum = 0;
        for(int i = 1 ; i <= number ; i++){
            sum+= Integer.parseInt(scanner.nextLine());
        }
        System.out.println("Sum = "+sum);
    }
}
