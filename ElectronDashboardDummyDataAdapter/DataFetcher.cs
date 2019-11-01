using AdapterUtils;
using System;
using System.Collections.Generic;

namespace ElectronDashboardDummyDataAdapter
{
    public class DataFetcher
    {
        public static void FetchAndFlushData(AdapterParams prms)
        {
            // get measurement id from command line arguments
            string measId = prms.MeasId;
            // get the start and end times
            DateTime startTime = prms.FromTime;
            DateTime endTime = prms.ToTime;

            // This Configuration data varaible Config_ can be handy here while dealing application secrets or configurations...
            ConfigurationManager Config_ = new ConfigurationManager();
            Config_.Initialize();

            // Create output data string
            string outStr = "";
            List<object> fetchResult = new List<object>();
            Random rand = new Random();
            for (DateTime dt = startTime; dt <= endTime; dt = dt.AddSeconds(1))
            {
                double ts = TimeUtils.ToMillisSinceUnixEpoch(dt);
                fetchResult.Add(ts);
                fetchResult.Add(rand.Next(-50, 50));
                if (prms.IncludeQuality)
                {
                    DataQuality qual = DataQuality.GOOD;
                    fetchResult.Add((int)qual);
                }
            }
            outStr = String.Join(",", fetchResult);

            // send the output data to console
            ConsoleUtils.FlushChunks(outStr);
        }
    }
}