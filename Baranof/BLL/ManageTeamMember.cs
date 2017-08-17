using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;

namespace BLL
{
    public class ManageTeamMember
    {
        #region Select Methods -- GetAllTeamMembers, GetAllTeamMembersOf, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<TeamMember> GetAllTeamMembers()
        {
            return Manage<TeamMember, TeamMemberRepository>.GetAll().Where(tm => tm.isDeleted == false).OrderBy(tm => tm.MemberType).ThenBy(tm => tm.MemberOrder).ToList();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<TeamMember> GetAllTeamMembersOf(string type)
        {
            return Manage<TeamMember, TeamMemberRepository>.GetAll().Where(tm => tm.isDeleted == false && tm.MemberType.ToLower().Equals(type.ToLower())).OrderBy(tm => tm.MemberOrder).ToList();
        }
        public static TeamMember GetById(int id)
        {
            return Manage<TeamMember, TeamMemberRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static TeamMember GetById(string id)
        {
            return Manage<TeamMember, TeamMemberRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddTeamMember
        public static bool AddTeamMember(TeamMember tm)
        {
            tm.Created = DateTime.Now.Date;
            tm.Modified = DateTime.Now.Date;

            return Manage<TeamMember, TeamMemberRepository>.Add(tm);
        }
        #endregion

        #region Update Methods -- UpdateTeamMember
        public static bool UpdateTeamMember(TeamMember tm)
        {

            tm.Modified = DateTime.Now.Date;
            return Manage<TeamMember, TeamMemberRepository>.Update(tm);

            //Log l = new Log();
            //TeamMember old_tm = GetById(tm.TeamMemberId);

            //tm.Modified = DateTime.Now.Date;
            //l.LogType = "Update";
            //l.ContentName = old_tm.FirstName + " " + old_tm.LastName;
            //l.OldValues = old_tm.TeamMemberId + "[lewis]" + old_tm.MemberType + "[lewis]" + old_tm.Prefix + "[lewis]" + old_tm.FirstName + "[lewis]" + old_tm.MiddleName + "[lewis]" + old_tm.LastName + "[lewis]" + old_tm.Suffix + "[lewis]" + old_tm.MemberTitle + "[lewis]" + old_tm.MemberEmail + "[lewis]" + old_tm.MemberPhone + "[lewis]" + old_tm.MemberLinkedIn + "[lewis]" + old_tm.MembervCard + "[lewis]" + old_tm.MemberLinkedIn + "[lewis]" + old_tm.MemberPicture + "[lewis]" + old_tm.MemberBriefIntro + "[lewis]" + old_tm.MemberBio + "[lewis]" + old_tm.MemberOrder;
            //l.NewValues = tm.TeamMemberId + "[lewis]" + tm.MemberType + "[lewis]" + tm.Prefix + "[lewis]" + tm.FirstName + "[lewis]" + tm.MiddleName + "[lewis]" + tm.LastName + "[lewis]" + tm.Suffix + "[lewis]" + tm.MemberTitle + "[lewis]" + tm.MemberEmail + "[lewis]" + tm.MemberPhone + "[lewis]" + tm.MemberLinkedIn + "[lewis]" + tm.MembervCard + "[lewis]" + tm.MemberLinkedIn + "[lewis]" + tm.MemberPicture + "[lewis]" + tm.MemberBriefIntro + "[lewis]" + tm.MemberBio + "[lewis]" + tm.MemberOrder;

            //return Manage<TeamMember, TeamMemberRepository>.Backup(l, tm, "Update");
        }
        #endregion

        #region Delete Methods -- DeleteTeamMember
        public static bool DeleteTeamMember(TeamMember tm)
        {


            tm.isDeleted = true;

          return  UpdateTeamMember(tm);

            //Log l = new Log();

            //tm.Modified = DateTime.Now.Date;
            //tm.isDeleted = true;
            //l.LogType = "Delete";
            //l.ContentName = tm.FirstName + " " + tm.LastName;
            //l.OldValues = tm.TeamMemberId + "[lewis]" + tm.MemberType + "[lewis]" + tm.Prefix + "[lewis]" + tm.FirstName + "[lewis]" + tm.MiddleName + "[lewis]" + tm.LastName + "[lewis]" + tm.Suffix + "[lewis]" + tm.MemberTitle + "[lewis]" + tm.MemberEmail + "[lewis]" + tm.MemberPhone + "[lewis]" + tm.MemberLinkedIn + "[lewis]" + tm.MembervCard + "[lewis]" + tm.MemberLinkedIn + "[lewis]" + tm.MemberPicture + "[lewis]" + tm.MemberBriefIntro + "[lewis]" + tm.MemberBio + "[lewis]" + tm.MemberOrder;

            //return Manage<TeamMember, TeamMemberRepository>.Backup(l, tm, "Delete");
        }
        #endregion


    }
}
