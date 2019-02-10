using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    GameObject dummyPlaceHolder;
    public void OnDrop(PointerEventData eventdata) {
        GameObject dropped_obj = eventdata.pointerDrag;

        /*
         * 取得拖曳中的牌 將他的dropZone 設定為當前DragZone 
         */
        DraggableCard d = dropped_obj.GetComponent<DraggableCard>();
        if (d != null) {
            d.dropZone = this.gameObject.transform;
        }
        Destroy(dummyPlaceHolder);

    }

    public void OnPointerEnter(PointerEventData eventData) {
        // 如果沒有抓著卡片就return
        if (eventData.pointerDrag == null)
            return;

        GameObject card = eventData.pointerDrag;
        DraggableCard draggableCard = card.GetComponent<DraggableCard>();

        //  新增placeholder
        dummyPlaceHolder = new GameObject();
        Vector2 cardSize = card.GetComponent<RectTransform>().sizeDelta;
        draggableCard.dummyPlaceholder = dummyPlaceHolder;
        LayoutElement le = dummyPlaceHolder.AddComponent<LayoutElement>();
        dummyPlaceHolder.GetComponent<RectTransform>().sizeDelta = cardSize;
        le.preferredHeight = cardSize.x;
        le.preferredWidth = cardSize.y;
        // le.flexibleHeight = 0;
        // le.flexibleWidth = 0;
        dummyPlaceHolder.transform.SetParent(draggableCard.dropZone);

    }

    public void OnPointerExit(PointerEventData eventData) {
        //if (dummyPlaceHolder != null)
        //Destroy(dummyPlaceHolder);
    }
}