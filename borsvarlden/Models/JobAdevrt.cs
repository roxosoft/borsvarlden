using System;
using System.Collections.Generic;

namespace borsvarlden.Models
{
    public class JobAdvert
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Label { get; set; }

        public string Preamble { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime EndingDateOfApplication { get; set; }

        public string Logo { get; set; }

        public string Image { get; set; }

        public List<JobCandidateApply>  JobCandidateApplies { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsAzureStorage { get; set; }

        public string Email { get; set; }
    }
}
