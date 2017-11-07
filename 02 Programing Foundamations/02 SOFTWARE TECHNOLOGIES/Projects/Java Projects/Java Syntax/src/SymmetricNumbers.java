import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class SymmetricNumbers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numnber = Integer.parseInt(scanner.nextLine());

        ArrayList<Integer> result = new ArrayList<Integer>();


        for (int i = 1 ; i <= numnber ; i++){
            if (currentNumberIsSimetric(i)){
                result.add(i);
            }
        }

        String formattedString = result.toString()
                .replace(",", "")  //remove the commas
                .replace("[", "")  //remove the right bracket
                .replace("]", "")  //remove the left bracket
                .trim();           //remove trailing spaces from partially initialized arrays

        System.out.println(formattedString);
    }

    private static boolean currentNumberIsSimetric(int decimalNumber) {
        char[] number =new Integer(decimalNumber).toString().toCharArray();
        int lenght = number.length;
        boolean result = true;
        for(int i = 0 ; i < lenght/2;i++){
            if (number[i]!=number[lenght-1-i]){
                result=false;
                break;
            }
        }
        return result;
    }
}
