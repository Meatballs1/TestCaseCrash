using System;
using Neo4j.Driver.V1;
using System.Collections.Generic;

namespace TestCaseCrash
{
    class MainClass
    {
        private const String OBJECT_QUERY = @"MATCH (n:ObjectDN)
                                            WHERE n.constructed = false
                                            RETURN n.name as dn,
                                            n.cn as cn,
                                            n.objectclass as objectclass,
                                            n.sid as sid,
                                            n.displayname as displayname,
                                            n.ntsd as ntsd,
                                            n.gplink as gplink,
                                            n.primarygroupid as primarygroupid,
                                            n.sidhistory as sidhistory,
                                            n.admincount as admincount,
                                            n.serviceprincipalname as serviceprincipalname,
                                            n.samaccountname as samaccountname,
                                            n.userworkstations as userworkstations,
                                            n.useraccountcontrol as useraccountcontrol,
                                            n.msdsallowedtodelegateto as allowedtodelegate,
                                            n.schemdaidguid as schemaidguid,
                                            n.ldapdisplayname as ldapdisplayname,
                                            n.originatingdomain as originatingdomain";
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Start");
            using (IDriver driver = GraphDatabase.Driver("bolt://172.17.0.4"))
            {  
                using (ISession session = driver.Session())
                {
                    IStatementResult result = session.Run(OBJECT_QUERY);
                    foreach (var record in result)
                    {
                        var cn = record["cn"].As<string>();
                        var dn = record["dn"].As<string>();
                        String[] objClass = null;
                        if (record["objectclass"] != null)
                        {
                            objClass = record["objectclass"].As<List<string>>().ToArray();
                        }
                        var objSID = record["sid"].As<string>();
                        var displayName = record["displayname"].As<string>();
                        var ntsd = record["ntsd"].As<string>();
                        var gplink = record["gplink"].As<string>();
                        var primarygroupid = record["primarygroupid"].As<string>();
                        String[] sidhistory = null;
                        if (record["sidhistory"] != null)
                        {
                            sidhistory = record["sidhistory"].As<List<string>>().ToArray();
                        }
                        var admincount = record["admincount"].As<UInt32?>();
                        String[] serviceprincipalname = null;
                        if (record["serviceprincipalname"] != null)
                        {
                            serviceprincipalname = record["serviceprincipalname"].As<List<string>>().ToArray();
                        }
                        var samaccountname = record["samaccountname"].As<string>();
                        String[] userworkstations = null;
                        if (record["userworkstations"] != null)
                        {
                            userworkstations = record["userworkstations"].As<List<string>>().ToArray();
                        }
                        var useraccountcontrol = record["useraccountcontrol"].As<UInt32?>();
                        String[] msdsallowedtodelegateto = null;
                        if (record["allowedtodelegate"] != null)
                        {
                            msdsallowedtodelegateto = record["allowedtodelegate"].As<List<string>>().ToArray();
                        }

                        var ldapdisplayname = record["ldapdisplayname"].As<string>();
                        var schemaidguid = record["schemaidguid"].As<string>();
                        var originatingdomain = record["originatingdomain"].As<string>();
                        Console.Write(".");
                    }
                }
            }
        }
    }
}
