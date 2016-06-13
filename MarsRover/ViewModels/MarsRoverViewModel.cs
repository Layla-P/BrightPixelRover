using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarsRover.ViewModels
{
    public class MarsRoverViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string StartingLocation { get; set; }

        [Required]
        //[RegularExpression(@"[LMRlmr]", ErrorMessage =
        //    "Your directions are not understood")]
        public string Directions { get; set; }

    }

    public class RemoteControlActionRequestViewModel
    {
        public RemoteControlActionRequestViewModel(){
            ListOfRovers = new List<MarsRoverViewModel>();
        }
        [Required]
        public List<MarsRoverViewModel> ListOfRovers { get; set; }


        public int AreaX { get; set; }
        public int AreaY { get; set; }
    }

    public class MarsRoverReturnViewModel
    {
        public int Id { get; set; }
        public string EndLocation { get; set; }
    }

    public class ReturnRemoteControlActionRequestViewModel
    {
        public ReturnRemoteControlActionRequestViewModel()
        {
            ListOfRovers = new List<MarsRoverReturnViewModel>();
        }
        public List<MarsRoverReturnViewModel> ListOfRovers { get; set; }
    }
}