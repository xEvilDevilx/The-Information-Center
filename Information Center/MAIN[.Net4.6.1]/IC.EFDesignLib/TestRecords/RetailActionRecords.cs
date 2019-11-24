using IC.EFDesignLib.Interfaces;
using System;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Retail Action Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class RetailActionRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var retailAction = new RetailAction()
                {
                    ActivityStatus = 1,
                    CaptionID = 100001,
                    DateBegin = new DateTime(2017, 04, 01),
                    DateEnd = new DateTime(2117, 03, 31),
                    DescriptionID = 101001,
                    RetailActionID = 1
                };
                context.RetailAction.Add(retailAction);

                retailAction = new RetailAction()
                {
                    ActivityStatus = 1,
                    CaptionID = 100002,
                    DateBegin = new DateTime(2017, 04, 01),
                    DateEnd = new DateTime(2117, 03, 31),
                    DescriptionID = 101002,
                    RetailActionID = 2
                };
                context.RetailAction.Add(retailAction);

                retailAction = new RetailAction()
                {
                    ActivityStatus = 1,
                    CaptionID = 100003,
                    DateBegin = new DateTime(2017, 04, 01),
                    DateEnd = new DateTime(2117, 03, 31),
                    DescriptionID = 101003,
                    RetailActionID = 3
                };
                context.RetailAction.Add(retailAction);

                retailAction = new RetailAction()
                {
                    ActivityStatus = 1,
                    CaptionID = 110001,
                    DateBegin = new DateTime(2017, 04, 01),
                    DateEnd = new DateTime(2117, 03, 31),
                    DescriptionID = 111001,
                    RetailActionID = 4
                };
                context.RetailAction.Add(retailAction);

                retailAction = new RetailAction()
                {
                    ActivityStatus = 1,
                    CaptionID = 110002,
                    DateBegin = new DateTime(2017, 04, 01),
                    DateEnd = new DateTime(2117, 03, 31),
                    DescriptionID = 111002,
                    RetailActionID = 5
                };
                context.RetailAction.Add(retailAction);

                retailAction = new RetailAction()
                {
                    ActivityStatus = 1,
                    CaptionID = 110003,
                    DateBegin = new DateTime(2017, 04, 01),
                    DateEnd = new DateTime(2117, 03, 31),
                    DescriptionID = 111003,
                    RetailActionID = 6
                };
                context.RetailAction.Add(retailAction);

                context.SaveChanges();
            }
        }
    }
}