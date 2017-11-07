import java.util.Arrays;
import java.util.Scanner;

public class ThreeIntegersSum {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int [] nums = Arrays
                .stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt).toArray();
        boolean result = false;
        for(int i = 0 ; i < 3; i ++){
            int num1 = nums[i%3];
            int num2 = nums[(i+1)%3];
            int num3 = nums[(i+2)%3];


            if (elementsOfSumValidation(num1,num2,num3)){
                if(!result)
                {
                    result=true;
                }

                printResult(num1,num2,num3);
                if (num1==0||num2==0||num3==0){
                    break;
                }
            }
        }
        if(!result){
            System.out.printf("No");
        }
    }

    private static void printResult(int num1, int num2, int num3) {

        int minNumber = Math.min(num1,num2);
        int maxNumber = Math.max(num1,num2);

        System.out.printf("%d + %d = %d%n",minNumber,maxNumber,num3);
    }

    private static boolean elementsOfSumValidation(int num1, int num2, int num3) {

        if (num1+num2==num3)
        {
            return true;
        }
        return false;
    }

}
