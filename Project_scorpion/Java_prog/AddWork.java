//USAGE:	java AddWork > wk.csv
//
//https://docs.oracle.com/javase/8/docs/api/
//
// Many to one correlation between parent_award_id, award_id_piid and Work.
// Want to add Work text to data file.
//
// PRE CONDITIONS
// cv.csv created
// parent_award_id moved to first column.
// award_id_piid moved to second column.
// Column added after award_id_piid column labeled as Work.
// Data file sorted on parent_award_id, award_id_piid.
// Has Header record and at least one data record.
// Text file w/2x array showing parent_award_id and award_id_piid to Work relation, also sorted by parent_award_id, and award_id_piid but no duplicates.
// Ensure no trailing commas in Work.csv
// 
// HARDCODED FILENAMES OF Work.csv and cv.csv are used.
// Array for Work currently 8192.
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
// <parent_award_id>,<award_id_piid>,,
//
// with 
//
// <parent_award_id>,<award_id_piid>,<Work>,
//
// so as to maintain number of commas, which will maintain the "schema" of data file as comma delimited table.
//
// Want to do this substitution for all parent_award_id and award_id_piid that have an associated Work.
// Want to do this in one pass.
//
// Load Work data into array and start with first element of first column.
// Open data file and start with first record.
// 
// While data file records remain and last array.parent_award_id and array.award_id_piid <= table.parent_award_id and table.award_id_piid
//
//	if array == table, set table.Work = array.Work and advance to next table record.
//
//	if > , advance to next table record.
//
//	if  < , advance to next array row.
//
import java.util.Scanner;
import java.io.File;
import java.io.FileNotFoundException;

public class AddWork
{
public static void main(String args[])
{
	String Work[][] = new String [8196][3];
	String wk = new String();
	String record = new String();
	String modRecord = new String();
	String left = new String();
	String right = new String();
	String comma = new String(",");
	String tableParentAwardID = new String();
	String tableAwardIDPiid = new String();
	String arrayWork = new String();
	String arrayParentAwardID = new String();
	String arrayAwardIDPiid = new String();

	int row = 0;
	int count = 0;
	int headerCount = 0;
	int dataRecordReadCount = 0;
	int dataRecordPrintCount = 0;
	int modifiedCount = 0;
	int wkMaxRowIndex = 0;
	int index = 0;
	int index2 = 0;
	int compareResult = 0;
	int length1 = 0;

	
	boolean EOT = false;	//EOT when last record read.
	boolean EOA = false;	//EOA when last array element read and it's > than remaining table elements.
	boolean	RECPRINT = false;  //test to ensure all records printed
	boolean ARRAYINC = false;  //flow control for checking incrementing array element against current table record.

/************
	System.out.println("Populating Work array...");
	System.out.println();
************/

	try
	{
		File file= new File("Work.csv");
		Scanner input;
		input = new Scanner(file).useDelimiter("\\n");

		while (input.hasNext())
		{
			wk = input.next();

			length1 = wk.length();
			index = wk.indexOf(",");
			Work[count][0] = wk.substring(0, index);

			//index = wk.indexOf(",", index + 1);
			wk = wk.substring(index + 1, length1 - 1);
			length1 = wk.length();
			index = wk.indexOf(",");
			Work[count][1] = wk.substring(0, index);

			Work[count][2] = wk.substring(index + 1, length1);
			count++;
		}

		input.close();

	} //end try

	catch (FileNotFoundException e)
	{
		e.printStackTrace();
	}

/*************
	System.out.printf("%d Work records added.", count);
	System.out.println();
	for (int i = 0; i < count; i++)
	{
		System.out.printf("%d\t%s\t%d\t%s\t%d\t%s\t%d",i, Work[i][0], Work[i][0].length(), Work[i][1], Work[i][1].length(), Work[i][2], Work[i][2].length());
		System.out.println();
	}
	System.out.println();
********/

	wkMaxRowIndex = count - 1; 

	File file= new File("cv.csv");
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

			arrayParentAwardID = Work[arrayRow][0];
			arrayAwardIDPiid = Work[arrayRow][1];
			arrayWork = Work[arrayRow][2];

			if (!ARRAYINC)	//When array incremented, need to compare to current record first, not next.
			{
				record = inputStream.next();
				dataRecordReadCount++;
				RECPRINT = false;

				index = record.indexOf(",");	//location of first comma
				tableParentAwardID = record.substring(0,index); //get first col from record sans comma for comparison.

				index2 = record.indexOf(",", index + 1);	//location of second comma
				tableAwardIDPiid = record.substring(index + 1, index2); //get second col
			}
			else
			{
				ARRAYINC = false;
			}
	
			compareResult = compare(arrayParentAwardID, arrayAwardIDPiid, tableParentAwardID, tableAwardIDPiid);

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
					left = left.concat(tableAwardIDPiid);
					left = left.concat(comma);
					left = left.concat(Work[arrayRow][2]);
					left = left.concat(record.substring(index2 + 1));
					System.out.printf("%s\n",left);
					modifiedCount++;
					dataRecordPrintCount++;
					RECPRINT = true;
					if (!inputStream.hasNext()) EOT = true;
					break;
				}

				case -1:	//no match but have to check current table record with next array element so can't print record yet.
				{
					if(arrayRow == wkMaxRowIndex)
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

public static int compare(String a, String b, String c, String d)
{
	int result = 1;
	int returnVal = 1;

	result= a.compareToIgnoreCase(c);

	if (result < 0)
	{
		returnVal = -1;
	}
	else
	{
		if (result > 0)
		{
			returnVal = 1;
		}
		else
		{
			if (result == 0)
			{
				result = b.compareToIgnoreCase(d);

				if (result < 0)
				{
					returnVal = -1;
				}
				else
				{
					if (result > 0)
					{
						returnVal = 1;
					}
					else
					{
						if (result == 0)
						{
							returnVal = 0;
						}
					}
				}
			}
		}
	}

	return returnVal;
} //end Compare()
} //end TestMain