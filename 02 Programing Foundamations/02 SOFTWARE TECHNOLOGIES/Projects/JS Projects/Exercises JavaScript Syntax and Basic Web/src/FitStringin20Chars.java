import java.util.Scanner;

public class FitStringin20Chars {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        if (text.length() < 20) {
            int diff = 20 - text.length();
            for (int i = 0 ; i <diff; i++){
                text+="*";
            }

        } else if (text.length()>20){
           text = text.substring(0, 20);
        }
        System.out.println(text);
    }
}
