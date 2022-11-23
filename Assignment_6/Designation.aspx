<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="Assignment_6.Designation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:antiquewhite">
    <form id="form1" runat="server">
        <div>
            <h2 align="center">Employee Registration</h2>
            <table align="center">
                <tr>
                    <td>
                        Designation :
                    </td>
                    <td> <asp:TextBox ID="textdesg" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td>Department :
                </td>
            <td><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList> </td>
          </tr>  
                <tr>
                    <td colspan="2" align="center"><asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"/></td>
                </tr>
            </table>
        </div>
         <table align="center">
                <tr>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DesignationId" OnRowEditing="Gridview1_RowEditing" OnRowUpdating="Gridview1_RowUpdating" OnRowCancelingEdit="Gridview1_RowCancelingEdit" OnRowDeleting="Gridview1_RowDeleting">
                            <Columns>
            
                                <asp:BoundField DataField="DesignationId" HeaderText="Designation ID" />                 
                                <asp:BoundField DataField="DesignationName" HeaderText="Designation Name" />
                                <asp:BoundField DataField="DepartmentId" HeaderText="Department_Id" />
                                <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" />
                               
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
        </table>
    </form>
</body>
</html>
