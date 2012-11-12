using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace candidate
{
    class Program
    {
        static void Main(string[] args)
        {
            sfdc.SforceService s = new sfdc.SforceService();
            sfdc.LoginResult token = s.login("<put your email here>", "<put your password here>");
            s.SessionHeaderValue = new sfdc.SessionHeader();
            s.SessionHeaderValue.sessionId = token.sessionId;
            s.Url = token.serverUrl;
            sfdc.sObject[] objs = new sfdc.sObject[1];

            /*
            sfdc.School__c school = new sfdc.School__c();
            school.Name = "Siegel High School";
            school.City__c = "Murfreesboro";
            school.State__c = "Tennessee";
            objs[0] = school;

            */

            /*
            sfdc.Candidate__c c = new sfdc.Candidate__c();
            */

            /*
            sfdc.Contact con = new sfdc.Contact();
            con.FirstName = "John";
            con.LastName = "Ingalls";

            c.Weight__c = 208;
            c.Contact__r = con;
            objs[0] = c;
            */

            /*
            sfdc.SaveResult[] sr = s.create(objs);
            Console.WriteLine(sr[0].success);
            */

            /*
            sfdc.sObject[] objs = new sfdc.sObject[1];
            sfdc.Contact c = new sfdc.Contact();
            c.FirstName = "John";
            c.LastName = "McCartney";
            objs[0] = c;
            sfdc.SaveResult[] sr = s.create(objs);
            Console.WriteLine(sr[0].success);
            */

            
            
            sfdc.QueryResult qr = s.query("select Name, Weight__c, Height__c, Section__c,  High_School__r.Name, High_School__r.City__c, High_school__r.State__c, College__r.Name, College__r.City__c, College__r.State__c, Contact__r.FirstName, Contact__r.LastName, Contact__r.Email from Candidate__c");
            
            foreach (sfdc.sObject a in qr.records)
            {
                sfdc.Candidate__c candidate = (sfdc.Candidate__c)a;

                if (candidate.Contact__r.LastName == "Ingram")
                {
                    candidate.Contact__c = "003d000000VDgCvAAL";
                    candidate.Contact__r.LastName = "O'Malley";
                }
                Console.WriteLine(candidate.Name);
                Console.WriteLine(candidate.Contact__r.LastName);
               
                
                
            }
            Console.ReadLine();
            
        }
    }
}
