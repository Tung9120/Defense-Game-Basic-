using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tung9120.DefenseBasic
{
    public class ShopDialog : Dialog, IComponentChecking
    {
        public Transform gridRoot;
        public ShopItemUI itemUIPrefab;
        public ShopManager m_shopMng;
        public GameManager m_gm;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            m_shopMng = FindObjectOfType<ShopManager>();
            m_gm = FindObjectOfType<GameManager>();

            UpdateUI();
        }

        public bool IsComponentsNull()
        {
            return m_shopMng == null && m_gm == null || gridRoot == null;
        }

        private void UpdateUI()
        {
            if (IsComponentsNull()) return;

            ClearChilds();

            var items = m_shopMng.items;

            if (items == null || items.Length <= 0) return;

            for(int i = 0; i < items.Length; i++)
            {
                int idx = i;

                var item = items[idx];

                var itemUIClone = Instantiate(itemUIPrefab, Vector3.zero, Quaternion.identity);

                itemUIClone.transform.SetParent(gridRoot);
                itemUIClone.transform.localScale = Vector3.one;
                itemUIClone.transform.localPosition = Vector3.zero;
                itemUIClone.UpdateUI(item, idx);
            }
        }

        public void ClearChilds()
        {
            if (gridRoot == null || gridRoot.childCount <= 0) return;

            for(int i = 0; i < gridRoot.childCount; i++)
            {
                var child = gridRoot.GetChild(i);

                if (child)
                    Destroy(child.gameObject);
            }
        }
    }
}