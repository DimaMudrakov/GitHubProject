using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gallery
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DisplayImage();

            }

        }
        public void DisplayImage()
        {
            var context = new GalleryEntities();


            var resultFromDataBase = (  from Image in context.Image
                                        join Comment in context.Comment
                                        on Image.ID equals Comment.ImageID
                                        select new { Image, Comment }).ToArray();

            rptImage.DataSource = resultFromDataBase;

            rptImage.DataBind();
        }

    }



}