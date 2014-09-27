﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataTablesPagingDemo.WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div style="margin-top:20px;">
    <table id="products" class="table table-striped table-condensed">
	    <thead>
		    <tr>
			    <th style='width: 4%'>ProductID</th>
			    <th>ProductName</th>
			    <th>SupplierID</th>
			    <th style='width: 30%'>CategoryID</th>
			    <th style='width: 15%'>QuantityPerUnit</th>
			    <th style='width: 4%'>UnitPrice</th>
			    <th>UnitsInStock</th>
			    <th>UnitsOnOrder</th>
			    <th>ReorderLevel</th>
                <th>Discontinued</th>
		    </tr>
	    </thead>
	    <tbody>
	    </tbody>
    </table>
</div>

    <script type="text/javascript">
        $(document).ready(function () {

            $("#products").DataTable({
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "dataType": "json",
                    "url": "DefaultHandler.ashx",
                    "type": "POST",
                    "data": function (d) {
                        d = { data: JSON.stringify(d) };
                        return d;
                    }
                },
                "dom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
                "pagingType": "bootstrap",
                "columns": [
						{ "data": "ProductID" },
						{ "data": "ProductName" },
						{ "data": "SupplierID" },
						{ "data": "CategoryID" },
						{ "data": "QuantityPerUnit" },
						{ "data": "UnitPrice" },
						{ "data": "UnitsInStock" },
						{ "data": "UnitsOnOrder" },
						{ "data": "ReorderLevel" },
                        { "data": "Discontinued" }
                ]
            });
        });
    </script>
</asp:Content>
