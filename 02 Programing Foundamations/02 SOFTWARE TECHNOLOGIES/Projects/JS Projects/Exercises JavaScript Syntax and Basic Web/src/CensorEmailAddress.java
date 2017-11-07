import java.util.Scanner;

public class CensorEmailAddress {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String emailAdress = scanner.nextLine();

        String []emailAndDomain = emailAdress.split("@");

        String email = emailAndDomain[0];

        String domain = emailAndDomain[1];

        String replacement = convertEmail(email)+"@"+domain;

        String text = scanner.nextLine();

        String modifiedText = text.replaceAll(emailAdress,replacement);

        System.out.println(modifiedText);
    }

    private static String convertEmail(String email) {

        String replacement = "";

        for (int i = 0 ; i < email.length(); i++){
            replacement+= "*";
        }

        return replacement;
    }
}
