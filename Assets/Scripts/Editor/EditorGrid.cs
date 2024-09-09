using UnityEngine;

namespace Editor
{
    public class EditorGrid
    {
        private const float _leftPosition = -7.5f;
        private const float _upPosition = 4f;
        private const float _columnCount = 100f;
        private const float _lineCount = 12f;
        private const float _offsetDown = 0.5f;
        private const float _offsetRight = 1f;

        public Vector2 CheckPosition(Vector2 position)
        {
            var tempX = 0f;
            var tempY = 0f;
            var x = _leftPosition - _offsetRight / 2f;
            var y = _upPosition - _offsetDown / 2f;

            if (position.x > x && position.x < (x + _offsetRight * _columnCount) &&
                position.y < y && position.y > (y - _offsetDown * _lineCount))
            {
                for (int i = 0; i < _columnCount; i++)
                {
                    if (position.x > x && position.x < x + _offsetRight)
                    {
                        tempX = x + _offsetRight / 2f;
                        break;
                    }
                    else
                    {
                        x += _offsetRight;
                    }
                }

                for (int i = 0; i < _lineCount; i++)
                {
                    if (position.y < y && position.y > y - _offsetDown)
                    {
                        tempY = y - _offsetDown / 2f;
                        break;
                    }
                    else
                    {
                        y -= _offsetDown;
                    }
                }
            }
            else
            {
                Debug.LogError("Out of play zone");
            }

            return new Vector2(tempX, tempY);
        }
    }
}