using System;

namespace BalotoResults.Models
{
    public class Result
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public string Number { get; set; }
        //SuperBallot ?
        public bool IsPrize { get; set; }
        public string SecondChanceNumber { get; set; }
        public bool IsSecondChancePrize { get; set; }
        public DateTime Date { get; set; }
    }
}
