TestBinaryStringEvaluator.RunTests();

public class BinaryStringEvaluator
{
    public bool IsGoodBinaryString(string binaryString)
    {
        // Check if the string is null or empty
        if (string.IsNullOrEmpty(binaryString))
        {
            return false;
        }

        int count0 = 0;
        int count1 = 0;

        foreach (char c in binaryString)
        {
            if (c == '0')
            {
                count0++;
            }
            else if (c == '1')
            {
                count1++;
            }
            else
            {
                // Invalid character found
                return false;
            }

            // Check the second condition: for every prefix, the number of 1's should not be less than the number of 0's
            if (count1 < count0)
            {
                return false;
            }
        }

        // Check if the number of 0's and 1's are equal
        return count0 == count1;
    }
}

public class TestBinaryStringEvaluator
{
    public static void RunTests()
    {
        BinaryStringEvaluator evaluator = new BinaryStringEvaluator();

        // Test case 1: Valid "good" binary string
        string testString1 = "1100";
        Console.WriteLine($"Test 1 - Is the binary string '{testString1}' good? {evaluator.IsGoodBinaryString(testString1)}"); // Expected: True

        // Test case 2: Valid "good" binary string
        string testString2 = "1010";
        Console.WriteLine($"Test 2 - Is the binary string '{testString2}' good? {evaluator.IsGoodBinaryString(testString2)}"); // Expected: True

        // Test case 3: Invalid binary string (unequal number of 0's and 1's)
        string testString3 = "110";
        Console.WriteLine($"Test 3 - Is the binary string '{testString3}' good? {evaluator.IsGoodBinaryString(testString3)}"); // Expected: False

        // Test case 4: Invalid binary string (more 0's than 1's in prefix)
        string testString4 = "1001";
        Console.WriteLine($"Test 4 - Is the binary string '{testString4}' good? {evaluator.IsGoodBinaryString(testString4)}"); // Expected: False

        // Test case 5: Valid "good" binary string
        string testString5 = "111000";
        Console.WriteLine($"Test 5 - Is the binary string '{testString5}' good? {evaluator.IsGoodBinaryString(testString5)}"); // Expected: True

        // Test case 6: Invalid binary string (invalid characters)
        string testString6 = "110a";
        Console.WriteLine($"Test 6 - Is the binary string '{testString6}' good? {evaluator.IsGoodBinaryString(testString6)}"); // Expected: False

        // Test case 7: Invalid binary string (empty string)
        string testString7 = "";
        Console.WriteLine($"Test 7 - Is the binary string '{testString7}' good? {evaluator.IsGoodBinaryString(testString7)}"); // Expected: False

        // Test case 8: Invalid binary string (null string)
        string testString8 = null;
        Console.WriteLine($"Test 8 - Is the binary string '{testString8}' good? {evaluator.IsGoodBinaryString(testString8)}"); // Expected: False

        // Test case 9: Valid "good" binary string with alternating pattern
        string testString9 = "101010";
        Console.WriteLine($"Test 9 - Is the binary string '{testString9}' good? {evaluator.IsGoodBinaryString(testString9)}"); // Expected: True
    }
}


