using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Api
{
    public class DynamoDbHelper
    {

        private static string tableName = "CovidDtoDynamo";
        static AmazonDynamoDBClient client;
        public static void CreateExampleTable(AmazonDynamoDBClient _client)
        {

            client = _client;
            var request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = new List<AttributeDefinition>()
                {
             new AttributeDefinition
            {
            AttributeName = "Id",
            AttributeType = "N"
                 }
                },
                KeySchema = new List<KeySchemaElement>()
        {
                  new KeySchemaElement
             {
             AttributeName = "Id",
                 KeyType = "HASH"  //Partition key
    }
  },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 10,
                    WriteCapacityUnits = 5
                }
            };

            var response = client.CreateTable(request);

            WaitUntilTableReady(tableName);
        }
        private static void WaitUntilTableReady(string tableName)
        {
            string status = null;
            // Let us wait until table is created. Call DescribeTable.
            do
            {
                System.Threading.Thread.Sleep(5000); // Wait 5 seconds.
                try
                {
                    var res = client.DescribeTable(new DescribeTableRequest
                    {
                        TableName = tableName
                    });

                    Console.WriteLine("Table name: {0}, status: {1}",
                              res.Table.TableName,
                              res.Table.TableStatus);
                    status = res.Table.TableStatus;
                }
                catch (ResourceNotFoundException)
                {
                    // DescribeTable is eventually consistent. So you might
                    // get resource not found. So we handle the potential exception.
                }
            } while (status != "ACTIVE");
        }

    }
}
