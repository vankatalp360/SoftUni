import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Scanner;

public class CompareCharArrays {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char[] firstArr = scanner.nextLine().replace(" ", "").toCharArray();

        char[] secondArr = scanner.nextLine().replace(" ", "").toCharArray();

        int result = CompaireBothArr(firstArr,secondArr);

        if (result==-1){
            PrintResult(firstArr,secondArr);

        }
        else {
            PrintResult(secondArr,firstArr);
        }


    }

    private static void PrintResult( char[] firstArr, char[] secondArr) {

        PrintArr(firstArr);

        PrintArr(secondArr);

    }

    private static void PrintArr(char[] arr) {

        String result = Arrays.toString(arr).replaceAll("[ ,\\[\\]]+","");

        System.out.println(result);
    }

    private static int CompaireBothArr(char[] firstArr, char[] secondArr) {

        int minLenght = Math.min(firstArr.length, secondArr.length);

        for (int i = 0; i < minLenght; i++) {

            if (firstArr[i] > secondArr[i]) {
                return 1;
            }
            else if (firstArr[i]<secondArr[i]){
                return -1;
            }

            if ( i == minLenght-1){
                if (firstArr.length>secondArr.length){
                    return  1;
                }
                else {
                    return -1;
                }
            }
        }

        return 1;
    }
}
