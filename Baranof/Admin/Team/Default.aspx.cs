using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using BLL;

namespace Admin.Team
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/team/add");
        }

        protected void TeamGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = TeamGridView.DataKeys[TeamGridView.SelectedIndex].Values["TeamMemberId"].ToString();

            Response.Redirect(String.Format("~/team/edit/{0}", id));
        }

        protected void BoradGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = BoradGridView.DataKeys[BoradGridView.SelectedIndex].Values["TeamMemberId"].ToString();

            Response.Redirect(String.Format("~/team/edit/{0}", id));
        }

        protected void GridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Response.Redirect("~/team");
        }

        protected bool isFirst(object memberId)
        {
            if (memberId == null)
            {
                Response.Redirect("~/");
            }

            TeamMember member = ManageTeamMember.GetById(memberId.ToString());

            return member.MemberOrder == 1;
        }

        protected bool isLast(object memberId)
        {
            if (memberId == null)
            {
                Response.Redirect("~/");
            }

            TeamMember member = ManageTeamMember.GetById(memberId.ToString());

            return member.MemberOrder == ManageTeamMember.GetAllTeamMembersOf(member.MemberType).Last().MemberOrder;
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).Parent.Parent as GridViewRow;
            Control hiddenId = row.Cells[1].FindControl("HiddenTeamMemberId");
            int id = Int32.Parse(((Label)hiddenId).Text);
            int prevId = id;

            IList<TeamMember> content = ManageTeamMember.GetAllTeamMembersOf(ManageTeamMember.GetById(id).MemberType);

            for (int i = 0; i < content.Count; i++)
            {
                if (content[i].TeamMemberId == id)
                {
                    prevId = content[i - 1].TeamMemberId;
                    break;
                }
            }

            if (hiddenId != null)
            {
                TeamMember c = ManageTeamMember.GetById(id);
                TeamMember prev = ManageTeamMember.GetById(prevId);
                if (c != null)
                {
                    int temp = c.MemberOrder;
                    c.MemberOrder = prev.MemberOrder;
                    prev.MemberOrder = temp;

                    if (ManageTeamMember.UpdateTeamMember(c) && ManageTeamMember.UpdateTeamMember(prev))
                    {
                        Response.Redirect("~/team");
                    }
                }
            }
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).Parent.Parent as GridViewRow;
            Control hiddenId = row.Cells[1].FindControl("HiddenTeamMemberId");
            int id = Int32.Parse(((Label)hiddenId).Text);
            int nextId = id;

            IList<TeamMember> content = ManageTeamMember.GetAllTeamMembersOf(ManageTeamMember.GetById(id).MemberType);

            for (int i = 0; i < content.Count; i++)
            {
                if (content[i].TeamMemberId == id)
                {
                    nextId = content[i + 1].TeamMemberId;
                    break;
                }
            }

            if (hiddenId != null)
            {
                TeamMember c = ManageTeamMember.GetById(id);
                TeamMember next = ManageTeamMember.GetById(nextId);
                if (c != null)
                {
                    int temp = c.MemberOrder;
                    c.MemberOrder = next.MemberOrder;
                    next.MemberOrder = temp;

                    if (ManageTeamMember.UpdateTeamMember(c) && ManageTeamMember.UpdateTeamMember(next))
                    {
                        Response.Redirect("~/team");
                    }
                }
            }
        }
    }
}