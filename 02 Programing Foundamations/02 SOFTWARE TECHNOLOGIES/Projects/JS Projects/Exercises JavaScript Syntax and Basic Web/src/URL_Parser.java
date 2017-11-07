import java.util.Scanner;

public class URL_Parser {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();
        int protocolIndex = text.indexOf("://");
        String protocol ="";
        if(protocolIndex>0){
           protocol = text.substring(0,protocolIndex);
            text=text.substring(protocolIndex+3,text.length());
       }
        System.out.printf("[protocol] = \"%s\"%n", protocol);
        int serverIndex = text.indexOf("/");
        if (serverIndex>0){
            String server =text.substring(0,serverIndex);
            text=text.substring(serverIndex+1,text.length());
            System.out.printf("[server] = \"%s\"%n", server);
            System.out.printf("[resource] = \"%s\"%n", text);
        }
        else {
            System.out.printf("[server] = \"%s\"%n", text);
            System.out.println("[resource] = \"\"");
        }

    }
}
