import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

public class CountWorkingDays {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);


        ArrayList<ArrayList<Integer>> newTest = new ArrayList<ArrayList<Integer>>() {{
            add(new ArrayList<Integer>() {{
                add(1);
                add(0);
            }});
            add(new ArrayList<Integer>() {{
                add(3);
                add(2);
            }});
            add(new ArrayList<Integer>() {{
                add(1);
                add(4);
            }});
            add(new ArrayList<Integer>() {{
                add(6);
                add(4);
            }});
            add(new ArrayList<Integer>() {{
                add(24);
                add(4);
            }});
            add(new ArrayList<Integer>() {{
                add(6);
                add(8);
            }});
            add(new ArrayList<Integer>() {{
                add(22);
                add(8);
            }});
            add(new ArrayList<Integer>() {{
                add(1);
                add(10);
            }});
            add(new ArrayList<Integer>() {{
                add(24);
                add(11);
            }});
            add(new ArrayList<Integer>() {{
                add(25);
                add(11);
            }});
            add(new ArrayList<Integer>() {{
                add(26);
                add(11);
            }});
        }};

        String firstText = scanner.nextLine();
        Date firstDate = ReadDate(firstText);
        String secondText = scanner.nextLine();
        Date secondDate = ReadDate(secondText);
        int counter = 0;
        Date startDate;
        Date endDate;
        if (firstDate.before(secondDate)) {
            startDate = firstDate;
            endDate = secondDate;
        } else {
            startDate = secondDate;
            endDate = firstDate;
        }
        Calendar start = Calendar.getInstance();
        start.setTime(startDate);
        Calendar end = Calendar.getInstance();
        end.setTime(endDate);
        end.add(Calendar.DATE, 1);
        for (start.getTime(); start.before(end); start.add(Calendar.DATE, 1)) {
            int dayOfWeek = start.get(Calendar.DAY_OF_WEEK);
            Integer day = start.get(Calendar.DAY_OF_MONTH);
            Integer month = start.get(Calendar.MONTH);
            if (CheckIfTheDayIsNotHoliday(dayOfWeek, day, month, newTest)) counter++;
        }
        System.out.println(counter);
    }

    private static Date ReadDate(String input) {

        try {
            DateFormat df = new SimpleDateFormat("dd-MM-yyyy");
            Date result = df.parse(input);
            return result;
        } catch (ParseException pe) {
            pe.printStackTrace();
        }
        return null;
    }

    private static boolean CheckIfTheDayIsNotHoliday(Integer dayOfWeek, Integer day, Integer month, ArrayList<ArrayList<Integer>> holidays) {

        if (dayOfWeek == 1 || dayOfWeek == 7)
            return false;

        boolean result = Holidays(day, month, holidays);
        if (result) return false;
        return true;
    }

    private static boolean Holidays(Integer day, Integer month, ArrayList<ArrayList<Integer>> holidays) {

        for (int i = 0; i < holidays.size(); i++) {
            if (holidays.get(i).get(0) == day) {
                if (holidays.get(i).get(1) == month) {
                    return true;
                }
            }
        }
        return false;
    }
}

