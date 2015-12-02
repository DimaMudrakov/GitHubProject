using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gallery
{
    public partial class EditComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ID = Request.QueryString["ID"];
                int CommentID = int.Parse(ID);

                GalleryEntities context = new GalleryEntities();

                var comment = context.Comment.Where(Comment => Comment.ID == CommentID);


                foreach (Comment CommentData in comment)
                {

                    txtComment.Text = CommentData.Imgtext;

                }
            }
        }

        protected void btnEditComment_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            string ID = Request.QueryString["ID"];
            int commentID = int.Parse(ID);

            GalleryEntities context = new GalleryEntities();

            var comment = new Comment();

            comment.Imgtext = txtComment.Text;
            comment.ID = commentID;
 
            context.Comment.Attach(comment);
            var entry = context.Entry(comment);
            entry.Property(c => c.Imgtext).IsModified = true;
            entry.Property(c => c.ID).IsModified = false;

            context.SaveChanges();
            lblMessage.Text = "Save changes";
        }
    }
}