import java.util.Scanner;

public class IntegertoHexandBinary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int dec = Integer.parseInt(scanner.nextLine());

        String hex = Integer.toHexString(dec).toUpperCase();
        System.out.println(hex);

        String bin = Integer.toBinaryString(dec);
        System.out.println(bin);
    }
}
