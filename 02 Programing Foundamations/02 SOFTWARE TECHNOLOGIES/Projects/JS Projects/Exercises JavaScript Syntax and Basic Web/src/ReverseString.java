import java.awt.*;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class ReverseString {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char[] sequance =scanner.nextLine().toCharArray();

        char[] result = new char[sequance.length];

        for (int i =sequance.length-1; i>=0; i--){
            result[sequance.length-1-i]= sequance[i];
        }

        String formatedResult = "";

        for(int i = 0 ; i < result.length;i++){
            formatedResult+=result[i];
        }

        System.out.println(formatedResult);
    }
}
