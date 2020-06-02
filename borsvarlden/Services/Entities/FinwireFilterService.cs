using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using borsvarlden.Db;
using borsvarlden.Helpers;
using borsvarlden.Models;
using borsvarlden.Services.Finwire;

namespace borsvarlden.Services.Entities
{

    public interface IFinwireFilterService
    {
        bool IsFilterPassed(FinWireData finwireData);
    }

    public class FinwireFilterService : IFinwireFilterService
    {
        private ApplicationContext _dbContext;

        public FinwireFilterService(ApplicationContext context)
        {
            _dbContext = context;
        }

        public bool IsFilterPassed(FinWireData finwireData)
        {
            //todo logging
            var contentPassed = IsContentFilterPassed(finwireData.HtmlText);
            var titleWhiteListPassed = IsTitleWhiteListPassed(finwireData.Title);
            var tittleBlackListNotPassed = IsTitleBlackFilterNotPassed(finwireData.Title);
            var contentTotalPassed = (contentPassed && !tittleBlackListNotPassed) || titleWhiteListPassed;
            var companiesPassed = IsCompaniesWhiteListPassed(finwireData.Companies);
            var soicalTagsPassed = IsSocialTagsWhiteListFilterPassed(finwireData.SocialTags);
            var termsPassed = companiesPassed || soicalTagsPassed;
            var filterPassed = contentTotalPassed && termsPassed;

            return filterPassed;   
        }

        public bool IsTitleWhiteListPassed(string title)
        {
            return ContainsSubstr(EnumFinwireFilterTypes._01_TitleWhitelist, title);
        }

        public bool IsTitleBlackFilterNotPassed(string title)
        {
            return ContainsSubstr(EnumFinwireFilterTypes._02_TitleBlackList, title);
        }

        public bool IsSocialTagsWhiteListFilterPassed(List<string> tags)
        {
            return IsTagWhitelistFilterPassed(EnumFinwireFilterTypes._03_TitleSocialTags,  tags);
        }

        public bool IsCompaniesWhiteListPassed(List<string> tags)
        {
            return IsTagWhitelistFilterPassed(EnumFinwireFilterTypes._04_FilterComplanies, tags);
        }

        public bool IsContentFilterPassed(string content)
        {
            var minPsossibleParagraphs = 3;

            //replace <br><br><br>... to <br><br>
            var contentUse= Regex.Replace(content, "([ \t]*<br>[ \t]*){3,}", "<br><br>");
            //remove <br><br> on the end of text
            contentUse = Regex.Replace(contentUse, "((<br>){2,}$)", String.Empty);

            var countBr = Regex.Matches(contentUse, "<br>[ \t]*<br>").Count;
            var countDblN = Regex.Matches(contentUse, "\n\n").Count;
            //Paragraphs = delimiters_count + the_last_paragraph
            if (countBr + countDblN  + 1  >= minPsossibleParagraphs)
                return true;

            return false;
        }

        private bool IsTagWhitelistFilterPassed(EnumFinwireFilterTypes type,  List<string> filtersApply)
        {
            if (filtersApply == null)
                return false;

            return _dbContext.FinwireFilters
                .Where(x => x.FinwireFilterType == type)
                .Select(e => e.Value.ToLower())
                .ToList()
                .Intersect(filtersApply.Select(y => y.ToLower()))
                .Any();
        }

        private bool IsTagWhitelistFilterPassed(EnumFinwireFilterTypes type, string value)
        {
            return Contains(type, value);
        }

        private bool IsTagBlackFilterNotPassed(EnumFinwireFilterTypes type, string value)
        {
            return Contains(type, value);
        }

        private bool Contains(EnumFinwireFilterTypes filterType, string value)
        {
            return _dbContext.FinwireFilters.Any(x =>
                x.FinwireFilterType == filterType && x.Value.ToLower() == value.ToLower());
        }

        private bool ContainsSubstr(EnumFinwireFilterTypes filterType, string value)
        {
            return _dbContext.FinwireFilters.Any(x =>
                x.FinwireFilterType == filterType && value.ToLower().Contains(x.Value.ToLower()));
        }
    }
}
