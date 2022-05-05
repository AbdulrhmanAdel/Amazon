using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Common.Query
{
    public class PagedModel
    {
        private int _pageSize;
        private int _currentPage;

        public int PageSize
        {
            get => _pageSize;
            set
            {
                switch (value)
                {
                    case > 50:
                        _pageSize = 50;
                        return;
                    case < 1:
                        _pageSize = 10;
                        return;
                    default:
                        _pageSize = value;
                        break;
                }
            }
        }


        public int CurrentPage
        {
            get => _currentPage;
            set => _currentPage = value < 1 ? 1 : value;
        }
    }
}