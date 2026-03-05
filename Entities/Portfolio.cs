using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;

namespace asp.net_youtube_course.Entities;

[Table("Portfolios")]
public class Portfolio
{
    public int StockId { get; set; }
    public string AppUserId { get; set; }
    public Stock stock { get; set; }
    public AppUser appUser { get; set; }
}
