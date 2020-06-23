using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 게시판
{
    public class Criteria
    {
        private int page;
        private int perPageNum;
        public string keyword { get; set; }

        public Criteria()
        {
            this.page = 1;
            this.perPageNum = 10;
        }

        public Criteria(int page, int perPageNum)
        {
            this.page = page;
            this.perPageNum = perPageNum;
        }        

        public void setPage(int page)
        {
            if (page <= 0)
            {
                this.page = 1;
                return;
            }
            this.page = page;
        }

        public void setPerPageNum(int perPageNum)
        {
            if (perPageNum <= 0 || perPageNum > 100)
            {
                this.perPageNum = 5;
                return;
            }
            this.perPageNum = perPageNum;
        }

        public int getPage()
        {
            return page;
        }

        public int getPageStart()
        {
            return (this.page - 1) * perPageNum;
        }
        public int getPageEnd()
        {
            return this.getPageStart() + this.getPerPageNum();
        }

        public int getPerPageNum()
        {
            return perPageNum;
        } 
    }
}