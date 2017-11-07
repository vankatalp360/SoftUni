import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ChangetoUppercase {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        String pattern = "<upcase>.*?<\\/upcase>";

        Pattern r = Pattern.compile(pattern);

        Matcher m = r.matcher(text);

        while(m.find()) {
            String match = m.group(0);
            String replacement = match.toUpperCase();
            text=text.replace(match,replacement);
        }
        text=text.replaceAll("<\\/UPCASE>","");
        text=text.replaceAll("<UPCASE>","");

        System.out.println(text);
    }
}
