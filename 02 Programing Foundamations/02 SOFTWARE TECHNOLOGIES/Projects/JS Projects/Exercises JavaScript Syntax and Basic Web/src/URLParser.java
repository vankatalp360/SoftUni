import java.util.Scanner;

public class URLParser {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();

        String[] protocolAndExt = text.split(":\\/\\/");
        String protocol;

        if (protocolAndExt.length >1) {
            protocol = protocolAndExt[0];
            System.out.printf("[protocol] = \"%s\"%n", protocol);


        } else {
            protocol = "";
            System.out.printf("[protocol] = \"%s\"%n", protocol);
        }

        text = text.replace(protocol + "://", "");

        String[] serverAndExt = text.split("/");

        if (serverAndExt.length >= 2) {
            String server = serverAndExt[0];

            System.out.printf("[server] = \"%s\"%n", server);

            String resource = text.replace(server + "/", "");

            System.out.printf("[resource] = \"%s\"%n", resource);
        } else {
            System.out.printf("[server] = \"%s\"%n", text);
            System.out.println("[resource] = \"\"");

        }
    }
}
