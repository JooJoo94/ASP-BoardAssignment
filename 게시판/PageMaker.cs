using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 게시판
{
    public class PageMaker
    {
        private int totalCount;
        private int startPage;
        private int endPage;
        private bool prev;
        private bool next;

        private int displayPageNum = 2;

        private Criteria cri;

        public int getTotalCount()
        {
            return totalCount;
        }

        public void setTotalCount(int totalCount)
        {
            this.totalCount = totalCount;
            calcData();
        }

        private void calcData()
        {
            endPage = (int)(Math.Ceiling(cri.getPage() / (double)displayPageNum) * displayPageNum);
            startPage = (endPage - displayPageNum) + 1;
            int tendPage = (int)(Math.Ceiling(totalCount / (double)cri.getPerPageNum()));

            if (endPage > tendPage)
                endPage = tendPage;
            prev = startPage == 1 ? false : true;
            next = endPage * cri.getPerPageNum() >= totalCount ? false : true;
        }

        public int getStartPage()
        {
            return startPage;
        }

        public int getEndPage()
        {
            return endPage;
        }

        public bool isPrev()
        {
            return prev;
        }

        public bool isNext()
        {
            return next;
        }

        public void setNext(bool next)
        {
            this.next = next;
        }

        public int getDisplayPageNum()
        {
            return displayPageNum;
        }

        public Criteria getCri()
        {
            return cri;
        }

        public void setCri(Criteria cri)
        {
            this.cri = cri;
        }
    }
}