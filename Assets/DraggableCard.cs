using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    Vector2 offset;
    [System.NonSerialized]
    public GameObject dummyPlaceholder;
    [System.NonSerialized]
    public Transform dropZone;
    public void OnBeginDrag(PointerEventData eventData) {
        // 讓滑鼠能正確拖曳 不會有一個位置閃爍
        Vector2 origin_pos = new Vector2(this.transform.position.x, this.transform.position.y);
        offset = origin_pos - eventData.position;

        // 預設dropZone, 最後的dropZone 是由DropZone.cs決定的
        dropZone = this.transform.parent;
        // 設定parent 讓 layout group運作
        //this.transform.parent = this.transform.parent.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("dragg");

        this.transform.position = eventData.position + offset;
                // if (dummyPlaceholder != null) {
                //     for (int i = 0; i < dropZone.transform.childCount; i++) {
                //         if (i == dummyPlaceholder.transform.GetSiblingIndex()) {
                //             continue;
                //         }
                //         if (eventData.position.x < dropZone.GetChild(i).position.x) {
                //             dummyPlaceholder.transform.SetSiblingIndex(i);
                //             break;
                //         }
                //     }
                // }
    }

    public void OnEndDrag(PointerEventData eventData) {
        //this.transform.parent = this.dropZone;
        this.transform.SetParent(this.dropZone);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}