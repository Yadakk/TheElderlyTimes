using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    [AddComponentMenu("Layout/Custom Content Size Fitter", 888)]
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    /// <summary>
    /// Resizes a RectTransform to fit the size of its content & the ability to modify the size of the parent as well
    /// </summary>
    /// <remarks>
    /// The ContentSizeFitter can be used on GameObjects that have one or more ILayoutElement components, such as Text, Image, HorizontalLayoutGroup, VerticalLayoutGroup, and GridLayoutGroup.
    /// </remarks>
    public class CustomContentSizeFitter : UIBehaviour, ILayoutSelfController
    {
        /// <summary>
        /// The size fit modes avaliable to use.
        /// </summary>
        public enum FitMode
        {
            /// <summary>
            /// Don't perform any resizing.
            /// </summary>
            Unconstrained,
            /// <summary>
            /// Resize to the minimum size of the content.
            /// </summary>
            MinSize,
            /// <summary>
            /// Resize to the preferred size of the content.
            /// </summary>
            PreferredSize
        }
        [SerializeField] protected FitMode m_HorizontalFit = FitMode.Unconstrained;


        /// <summary>
        /// The fit mode to use to determine the width.
        /// </summary>
        public FitMode HorizontalFit { get { return m_HorizontalFit; } set { if (SetPropertyUtility2.SetStruct(ref m_HorizontalFit, value)) SetDirty(); } }

        [SerializeField] protected FitMode m_VerticalFit = FitMode.Unconstrained;

        /// <summary>
        /// The fit mode to use to determine the height.
        /// </summary>
        public FitMode VerticalFit { get { return m_VerticalFit; } set { if (SetPropertyUtility2.SetStruct(ref m_VerticalFit, value)) SetDirty(); } }


        private DrivenRectTransformTracker m_Tracker;

        protected CustomContentSizeFitter()
        { }

        protected override void OnEnable()
        {
            base.OnEnable();
            SetDirty();
        }

        protected override void OnDisable()
        {
            m_Tracker.Clear();
            LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
            base.OnDisable();
        }

        protected override void OnRectTransformDimensionsChange()
        {
            SetDirty();
        }

        public virtual void SetLayoutHorizontal()
        {
            m_Tracker.Clear();
            HandleSelfFittingAlongAxis(0);
        }

        /// <summary>
        /// Calculate and apply the vertical component of the size to the RectTransform
        /// </summary>
        public virtual void SetLayoutVertical()
        {
            HandleSelfFittingAlongAxis(1);
        }
        [System.NonSerialized] private RectTransform m_Rect;
        [System.NonSerialized] private RectTransform m_parentRect;
        private RectTransform RectTransform
        {
            get
            {
                if (m_Rect == null)
                    m_Rect = GetComponent<RectTransform>();
                return m_Rect;
            }
        }
        private RectTransform ParentRectTransform
        {
            get
            {
                if (m_parentRect == null)
                    m_parentRect = RectTransform.parent.GetComponent<RectTransform>();
                return m_parentRect;
            }
        }
        private void HandleSelfFittingAlongAxis(int axis)
        {
            FitMode fitting = (axis == 0 ? HorizontalFit : VerticalFit);
            if (fitting == FitMode.Unconstrained)
            {
                // Keep a reference to the tracked transform, but don't control its properties:
                m_Tracker.Add(this, RectTransform, DrivenTransformProperties.None);
                return;
            }

            m_Tracker.Add(this, RectTransform, (axis == 0 ? DrivenTransformProperties.SizeDeltaX : DrivenTransformProperties.SizeDeltaY));

            // Set size to min or preferred size
            if (fitting == FitMode.MinSize)
                RectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis)axis, LayoutUtility.GetMinSize(m_Rect, axis));
            else
                RectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis)axis, LayoutUtility.GetPreferredSize(m_Rect, axis));

            if (applyToParent && ParentRectTransform != null)
            {
                if (fitting == FitMode.MinSize)
                    ParentRectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis)axis, LayoutUtility.GetMinSize(m_Rect, axis));
                else
                    ParentRectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis)axis, LayoutUtility.GetPreferredSize(m_Rect, axis));
            }
        }
        public bool applyToParent = true;

        protected void SetDirty()
        {
            if (!IsActive())
                return;

            LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            SetDirty();
        }
#endif

    }
}