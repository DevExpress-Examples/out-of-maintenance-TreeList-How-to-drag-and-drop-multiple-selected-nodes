<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/147423235/17.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830524)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# TreeList - How to drag and drop multiple selected nodes
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/147423235/)**
<!-- run online end -->

This sample illustrates how to drag and drop multiple nodes in **TreeList** when selection is enabled. To move selected nodes from one parent node to another, it is sufficient to change selected nodes' parent field values at the DataSource level. You can do this by handling the [MVCxClientTreeList.EndDragNode](https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxTreeList.Scripts.ASPxClientTreeList.EndDragNode.event) event and saving selected node keys to a global JavaScript array. Then, it is necessary to assign this array to the **customArgs** property in the [BeginCallback](https://docs.devexpress.com/AspNetMvc/js-MVCxClientTreeList.BeginCallback) event handler. On the server side, change parent field values in a controller action specified in the [NodeDragDropRouteValues](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.MVCxTreeListSettingsEditing.NodeDragDropRouteValues) property.

The most interesting part of this task is to show all selected nodes in a transparent popup during dragging. For this, you can handle the [StartDragNode](https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxTreeList.Scripts.ASPxClientTreeList.StartDragNode.event) event. When this event is raised, a div container is created after another container into which TreeList is placed. It is possible to find this container, clone a table row in the div container, and assign selected node values to cloned rows. The div container is created after the StartDragNode event is raised, so it is necessary to implement your own custom function and asynchronously call it in the StartDragNode event handler.

***See also:*** <br />[ASPxTreeList - How to drag and drop multiple nodes](https://github.com/DevExpress-Examples/aspxtreelist-how-to-drag-and-drop-multiple-nodes-t501420)
