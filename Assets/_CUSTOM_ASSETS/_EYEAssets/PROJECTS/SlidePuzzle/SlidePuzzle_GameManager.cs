using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle_GameManager : MonoBehaviour
{
    [SerializeField] Transform _gameTransform;
    [SerializeField] Transform _piecePrefab;

    List<Transform> _pieces;
    int emptyLocation;
    int size;
    bool _shuffling = false;

    private void CreateGamePieces(float gapThickness)
    {
        //this is the width of each tile
        float width = 1 / (float)size;

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(_piecePrefab, _gameTransform);
                //pieces will be on a game board going from -1 to +1
                _pieces.Add(piece);
                piece.localPosition = new Vector3   (-1 + (2 * width * col) + width,
                                                     +1 - (2 * width * row) - width,
                                                     0);
                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + col}";
                Debug.Log("Piece Name: " + piece.name);

                //we want an empty space in the bottom right
                if ((row == size - 1) && (col == size - 1))
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                { 
                    //we want to map the uv components correctly they are 0 ->1
                    float gap = gapThickness / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    //uv coordinate order: (0,1), (1,1), (0,0), (1,0)
                    uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row +1)) - gap));
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1- ((width * ( row +1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
                    uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));
                    //assign our new uvs to the mesh
                    mesh.uv = uv;
                }                       
            }
        }
    }

    void Start()
    {
        _pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);
    }

    void Update()
    {
        if(!_shuffling && CheckCompletion())
        {
            _shuffling = true;
            StartCoroutine(WaitShuffle(0.5f));
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                //go through the list , the index tells us the position
                for(int i = 0; i < _pieces.Count; i++)
                {
                    Debug.Log("i: " + i);
                    if (_pieces[i] == hit.transform)
                    {
                        //check each direction to see if valid move
                        Debug.Log(SwapIfValid(i, -size, size));
                        if (SwapIfValid(i, -size, size))   { break; }
                        if (SwapIfValid(i, +size, size))   { break; }
                        if (SwapIfValid(i, -1,    0))      { break; }
                        if (SwapIfValid(i, +1,    size-1)) { break; }

                    }
                }
            }
        }
    }
    

    private bool SwapIfValid(int i, int offset, int colCheck)
    {
        Debug.Log(i + "/" + offset + "/" + colCheck);
        if (((i % size) != colCheck) && ((i + offset) == emptyLocation))
        {
            //swap them in game state
            (_pieces[i], _pieces[i + offset]) = (_pieces[i + offset], _pieces[i]);
            //swap their transform
            (_pieces[i].localPosition, _pieces[i + offset].localPosition) = ((_pieces[i + offset].localPosition, _pieces[i].localPosition));
            //update empty location
            emptyLocation = 1;

            return true;
        }
        Debug.Log(i + offset + colCheck);
        return false;
    }


    private bool CheckCompletion()
    {
        for (int i = 0; i < _pieces.Count; i++)
        {
            if (_pieces[i].name != $"{i}")
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator WaitShuffle(float duration)
    {
        yield return new WaitForSeconds(duration);
        Shuffle();
        _shuffling = false;
    }

    private void Shuffle()
    {
        int count = 0;
        int last = 0;
        while (count < (size * size * size))
        {
            //pick a random location
            int rnd = Random.Range(0, size * size);
            //only thing we do is forbid undoing the last move
            if (rnd == last) { continue; }
            last = emptyLocation;
            //try surrounding spaces looking for valid move.
            if     (SwapIfValid(rnd, -size, size    ))     { count++; }
            else if(SwapIfValid(rnd, +size, size    ))     { count++; }
            else if(SwapIfValid(rnd, -1,    0       ))     { count++; }
            else if(SwapIfValid(rnd, +1,    size - 1))     { count++; }
        }
    }
}
