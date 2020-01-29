using Defiance.Bolton.Domain.ValueObjects;
using System;

namespace Defiance.Bolton.Domain.Entities
{
    public class ImportHistory
    {
        public ImportHistory()
        {
            this.DateCreated = DateTime.Now;
        }

        public Guid ImportHistoryId { get; set; }
        public DocumentType DocumentType { get; set; }
        public string CurrentPage { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateCompleted { get; set; }

        public static ImportHistory NewInstance()
        {
            return new ImportHistory();
        }

        public ImportHistory SetCurrentPage(string page)
        {
            this.CurrentPage = page;
            return this;
        }

        public ImportHistory SetCompleted()
        {
            this.DateCompleted = DateTime.Now;
            return this;
        }
    }
}
