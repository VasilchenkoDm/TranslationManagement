﻿using TranslationManagement.DataAccess.Entities.Base;
using TranslationManagement.Shared.Enums;

namespace TranslationManagement.DataAccess.Entities
{
    public class TranslationJob : BaseEntity
    {
        public string CustomerName { get; set; }
        public TranslationJobStatusEnum Status { get; set; }
        public string OriginalContent { get; set; }
        public string TranslatedContent { get; set; }
        public decimal Price { get; set; }
        public int? TranslatorId { get; set; }
        public Translator? Translator { get; set; }
    }
}
