﻿/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CodeMonkey.Utils;

public class InventoryTetrisDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private InventoryTetris inventoryTetris;
    private PlacedObject placedObject;
    private ItemInfo itemInfo;
    public bool isCreatItem;
    private void Awake() {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        placedObject = GetComponent<PlacedObject>();
        itemInfo = GetComponent<ItemInfo>();
    }

    public void Setup(InventoryTetris inventoryTetris) {
        this.inventoryTetris = inventoryTetris;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        //Debug.Log("OnBeginDrag");
        if (!Input.GetMouseButton(0)) return;
        canvasGroup.alpha = .7f;
        canvasGroup.blocksRaycasts = false;

        ItemTetrisSO.CreateVisualGrid(transform.GetChild(0), placedObject.GetPlacedObjectTypeSO() as ItemTetrisSO, inventoryTetris.GetGrid().GetCellSize());
        InventoryTetrisDragDropSystem.Instance.StartedDragging(inventoryTetris, placedObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!Input.GetMouseButtonUp(0)) return;
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        InventoryTetrisDragDropSystem.Instance.StoppedDragging(inventoryTetris, placedObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ItemTetrisSO itemSo = itemInfo.ItemSo;
        if (!StepManager.ToolActive_static())
        {
            if (!Input.GetMouseButtonDown(1)) return;
            StepManager.ShowTool_static(itemSo.itemname, itemInfo.ShippingAddress, itemInfo.NPCName, itemSo.weight + "kg");
        }
    }

}
