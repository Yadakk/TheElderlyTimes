using DG.Tweening;
using DimensionalLists;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ScreenChanger : MonoBehaviour
{
    public Matrix<GameObject> ScreenPrefabs;
    public float TransitionDurationSeconds;
    public Ease Ease;

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    private ShiftedAccessArray2D<RectTransform> _screens;
    private Vector2Int _currentCoordinates;

    private void Start()
    {
        _screens = new(CreateScreens(ScreenPrefabs.ToArray()));

        UpdateScreenPositions();
    }

    public void ChangeScreen(Vector2Int coordinateChange, TweenCallback callback)
    {
        Vector2Int targetCoordinates = _currentCoordinates + coordinateChange;

        Vector2Int newShift = _screens.Shift;

        if (targetCoordinates.x < 0) newShift.x += coordinateChange.x;
        if (targetCoordinates.x >= _screens.GetLength(0)) newShift.x += coordinateChange.x;
        if (targetCoordinates.y < 0) newShift.y += coordinateChange.y;
        if (targetCoordinates.y >= _screens.GetLength(1)) newShift.y += coordinateChange.y;

        Vector2Int shiftDifference = newShift - _screens.Shift;
        targetCoordinates -= shiftDifference;
        _currentCoordinates -= shiftDifference;
        _screens.Shift = newShift;

        UpdateScreenPositions();

        RectTransform.localPosition += (Vector3)CoordinatesToPosition(shiftDifference);

        transform.DOKill(false);
        RectTransform.DOLocalMove(-_screens[targetCoordinates.x, targetCoordinates.y].localPosition, TransitionDurationSeconds).SetEase(Ease).OnKill(callback);

        _currentCoordinates = targetCoordinates;
    }

    private RectTransform[,] CreateScreens(GameObject[,] screenPrefabs)
    {
        var screens = new RectTransform[screenPrefabs.GetLength(0), screenPrefabs.GetLength(1)];

        for (int x = 0; x < screens.GetLength(0); x++)
        {
            for (int y = 0; y < screens.GetLength(1); y++)
            {
                GameObject screenPrefab = screenPrefabs[x, y];
                if (!screenPrefab) continue;

                screens[x, y] = CreateScreen(screenPrefab);
            }
        }

        return screens;
    }

    private RectTransform CreateScreen(GameObject screenPrefab)
    {
        GameObject screen = Instantiate(screenPrefab);
        RectTransform screenRectTransform = screen.GetComponent<RectTransform>();

        screenRectTransform.SetParent(transform, true);
        screenRectTransform.localScale = RectTransform.localScale;
        screenRectTransform.sizeDelta = RectTransform.sizeDelta;

        return screenRectTransform;
    }

    private void UpdateScreenPositions()
    {
        for (int x = 0; x < _screens.GetLength(0); x++)
        {
            for (int y = 0; y < _screens.GetLength(1); y++)
            {
                _screens[x, y].localPosition = CoordinatesToPosition(new(x, y));
            }
        }
    }

    private Vector2 CoordinatesToPosition(Vector2Int coordinates)
    {
        return RectTransform.rect.size * coordinates;
    }
}