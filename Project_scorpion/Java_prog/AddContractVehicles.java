//USAGE:	java AddContractVehicles > cv.csv
//
//https://docs.oracle.com/javase/8/docs/api/
//
// Many to one correlation between parent_award_id and Contract Vehicle.
// Want to add Contract Vehicle text to data file.
//
// PRE CONDITIONS
// "Zero records" removed
// Empty parent_award_id fields are populated with that record's award_id_piid.
// parent_award_id moved to first column position.
// Column added after parent_award_id column labeled as Contract Vehicle.
// Data file sorted on parent_award_id.
// Has Header record and at least one data record.
// Text file w/2x array showing parent_award_id to Contract Vehicle relation, also sorted by parent_award_id, but no duplicate parent_award_ids.
// Ensure no trailing commas in ContractVehicles.csv
// 
// HARDCODED FILENAMES OF ContractVehicles.csv and PreCondition.csv are used.
// Array for ContractVehicles currently 1000.
// 
// Outputs file with stats at the bottom. Those rows should be removed. Use as sanity check.
//
// Exported data record would include:
//
// ,<parent_award_id>,,
// 
// which shows the inserted column afterwards as a blank field (comma delimited).
//
// Want to replace the string 
// 
// <parent_award_id>,,
//
// with 
//
// <parent_award_id>,<Contract Vehicle>,
//
// so as to maintain number of commas, which will maintain the "schema" of data file as comma delimited table.
//
// Want to do this substitution for all parent_award_id that have an associated Contract Vehicle.
// Want to do this in one pass.
//
// Load Contract Vehicle data into array and start with first element of first column.
// Open data file and start with first record.
// 
// While data file records remain and last array.parent_award_id <= table.parent_award_id
//
//	if array == table, set table.Contract Vehicle = array.Contract Vehicle and advance to next table record.
//
//	if  > , advance to next table record.
//
//	if < , advance to next array row.
//
import java.util.Scanner;
import java.io.File;
import java.io.FileNotFoundException;

public class AddContractVehicles
{
public static void main(String args[])
{
	String ContractVehicles[][] = new String [1000][2];
	String cv = new String();
	String record = new String();
	String modRecord = new String();
	String left = new String();
	String right = new String();
	String comma = new String(",");
	String tableParentAwardID = new String();
	String arrayContractVehicle = new String();
	String arrayParentAwardID = new String();

	int row = 0;
	int count = 0;
	int headerCount = 0;
	int dataRecordReadCount = 0;
	int dataRecordPrintCount = 0;
	int modifiedCount = 0;
	int cvMaxRowIndex = 0;
	int index = 0;
	int compareResult = 0;
	int length1 = 0;

	
	boolean EOT = false;	//EOT when last record read.
	boolean EOA = false;	//EOA when last array element read and it's > than remaining table elements.
	boolean	RECPRINT = false;  //test to ensure all records printed
	boolean ARRAYINC = false;  //flow control for checking incrementing array element against current table record.

/************
	System.out.println("Populating Contract Vehicle array...");
	System.out.println();
************/

	try
	{
		File file= new File("ContractVehicles.csv");
		Scanner input;
		input = new Scanner(file).useDelimiter("\\n");

		while (input.hasNext())
		{
			cv = input.next();
			length1 = cv.length();
			index = cv.indexOf(",");
			ContractVehicles[count][0] = cv.substring(0, index);
			ContractVehicles[count][1] = cv.substring(index + 1, length1 - 1);
			count++;
		}

		input.close();

	} //end try

	catch (FileNotFoundException e)
	{
		e.printStackTrace();
	}

/*************
	System.out.printf("%d Contract Vehicle records added.", count);
	System.out.println();
	for (int i = 0; i < count; i++)
	{
		System.out.printf("%d\t%s\t%d\t%s\t%d",i, ContractVehicles[i][0], ContractVehicles[i][0].length(), ContractVehicles[i][1], ContractVehicles[i][1].length());
		System.out.println();
	}
	System.out.println();
************/

	cvMaxRowIndex = count - 1; 

	File file= new File("PreCondition.csv");
	Scanner inputStream;

	int arrayRow = 0;

	try  //presuming at least one header and one record or will crash.
	{
		inputStream = new Scanner(file).useDelimiter("\\n");
		record = inputStream.next();	//don't care about headers
		System.out.printf("%s\n",record);	//will be printing out as we go
		headerCount++;

		while (!EOA && !EOT)
		{

			arrayParentAwardID = ContractVehicles[arrayRow][0];
			arrayContractVehicle = ContractVehicles[arrayRow][1];

			if (!ARRAYINC)	//When array incremented, need to compare to current record first, not next.
			{
				record = inputStream.next();
				dataRecordReadCount++;
				RECPRINT = false;

				index = record.indexOf(",");	//location of first comma
				tableParentAwardID = record.substring(0,index); //get first col from record sans comma for comparison.
			}
			else
			{
				ARRAYINC = false;
			}
	
			compareResult = compare(arrayParentAwardID, tableParentAwardID);

			switch (compareResult)
			{
				case 1:  //array element > table element
				{
					System.out.printf("%s\n",record);	//no match. Print and compare w/next table record.
					dataRecordPrintCount++;
					RECPRINT = true;
					if (!inputStream.hasNext()) EOT = true;
					break;
				}

				case 0:  //array element = table element
				{
					left = tableParentAwardID;
					left = left.concat(comma);
					left = left.concat(ContractVehicles[arrayRow][1]);
					left = left.concat(record.substring(index + 1));
					System.out.printf("%s\n",left);
					modifiedCount++;
					dataRecordPrintCount++;
					RECPRINT = true;
					if (!inputStream.hasNext()) EOT = true;
					break;
				}

				case -1:	//no match but have to check current table record with next array element so can't print record yet.
				{
					if(arrayRow == cvMaxRowIndex)
					{
						EOA = true;
					}
					else
					{
						arrayRow++;
						ARRAYINC = true;
						//System.out.println("> " + arrayParentAwardID + ", " + tableParentAwardID);
					}
					break;
				}
			} //end case
		} //end while

		if (!RECPRINT)
		{
			System.out.printf("%s\n", record);	//capture last record if need be
			dataRecordPrintCount++;
			RECPRINT = true;
		}


		if (EOA)
		{
			//System.out.println("exit on EOA");
		}

		if (EOT)
		{
			//System.out.println("exit on EOT");
		}
		else
		{
			while (inputStream.hasNext()) //array comparisons done. print out rest of table.
			{
				record = inputStream.next();
				dataRecordReadCount++;
				System.out.printf("%s\n",record);
				dataRecordPrintCount++;
			}
		}

		inputStream.close();

	} //end try

	catch (FileNotFoundException e)
	{
		e.printStackTrace();
	}

	System.out.println();
	System.out.println("Output:");
	System.out.println();
	System.out.printf("%d header record", headerCount);
	System.out.println();
	System.out.printf("%d data records read", dataRecordReadCount);
	System.out.println();
	System.out.printf("%d data records written", dataRecordPrintCount);
	System.out.println();
	System.out.printf("%d data records modified", modifiedCount);

} // end main()

public static int compare(String a, String b)
{
	int result = 1;
	int returnVal = 1;

	result= a.compareToIgnoreCase(b);

	if (result < 0)
	{
		returnVal = -1;
	}
	else
	{
		if (result == 0)
		{
			returnVal = 0;
		}
		else
		{
			if (result > 0)
			{
				returnVal = 1;
			}
		}
	}

	return returnVal;
} //end Compare()
} //end TestMain