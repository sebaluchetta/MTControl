﻿namespace MTControl.Models
{
    public class Pager
    {
        public int TotalItems
        {
            get; private set;
        }
        public int CurrentPage
        {
            get; private set;
        }
        public int PageSize
        {
            get; private set;
        }
        public int TotalPages
        {
            get; private set;
        }

        public int StartPage
        {
            get; private set;
        }
        public int EndPage
        {
            get; private set;
        }
       public int Skip         
        {
            get; private set;
        }
        public Pager ( int totalItems, int page, int pageSize = 10 )
        {
            int skip = (page - 1) * pageSize;
            int totalPages = (int)Math.Ceiling ( (decimal)totalItems / (decimal)pageSize );
            int currentPage = page;
            int startPage = currentPage - 1;
            int endPage = currentPage + 2;
            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }
            Skip=skip;
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            PageSize= pageSize;

        }

    }
}
