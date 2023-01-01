using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NavAgent : MonoBehaviour
{
    private PriorityQueue<Node> openList;
    private List<Node> closeList;

    private List<Vector3Int> routePath;

    public float speed;
    public bool cornerCheck = false;

    public bool isDebug = false;

    private Vector3Int currentPosition; // 현재 타일 위치
    private Vector3Int destination; //목표 타일 위치
    public Vector3Int Destination
    {
        get => destination;
        set
        {
            SetCurrentPosition();
            destination = value;
            CalcRoute();
            moveIdx = 0;
            //if (isDebug) PrintRoute();
        }
    }

    public bool CanMovePath => routePath.Count > moveIdx;

    private LineRenderer line;

    //private bool isMove = false;
    private int moveIdx = 0;
    private Vector3 nextPos;


    private void Awake()
    {
        openList = new PriorityQueue<Node>();
        closeList = new List<Node>();
        routePath = new List<Vector3Int>();
        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        SetCurrentPosition();
        
        transform.position = MapManager.Instance.GetWorldPos(currentPosition);
    }

    private void SetCurrentPosition()
    {
        Vector3Int cellPos = MapManager.Instance.GetTilePos(transform.position);
        currentPosition = cellPos;
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 0;
            Vector3 world = Camera.main.ScreenToWorldPoint(pos);
            Vector3Int cellPos = MapManager.Instance.GetTilePos(world);

            destination = cellPos;
            if (CalcRoute())
            {
                PrintRoute();
                moveIdx = 0;
                isMove = true;
                SetNextTarget();
            }
        }

        if (isMove)
        {
            Vector3 dir = nextPos - transform.position;
            transform.position += dir.normalized * speed * Time.deltaTime;
            if (dir.magnitude <= 0.1f)
            {
                SetNextTarget();
            }
        }
    }*/

    public Vector3Int GetNextTarget()
    {
        if(moveIdx >= routePath.Count)
        {
            //isMove = false;
            return Vector3Int.zero;
        }

        return routePath[moveIdx++];

        /*currentPosition = routePath[moveIdx];
        nextPos = MapManager.Instance.GetWorldPos(currentPosition);
        moveIdx++;*/
    }

    private void PrintRoute()
    {
        line.positionCount =routePath.Count;
        for(int i = 0; i < routePath.Count; i++)
        {
            Vector3 worldPos = MapManager.Instance.GetWorldPos(routePath[i]);
            line.SetPosition(i, worldPos);
        }
    }

    #region Astar 알고리즘
    private bool CalcRoute()
    {
        openList.Clear();
        closeList.Clear();

        openList.Push(new Node { pos = currentPosition, _parent = null, G = 0, F = CalcH(currentPosition) });

        bool result = false;
        int cnt = 0;

        while(openList.Count > 0)
        {
            Node n = openList.Pop();
            FindOpenList(n);
            closeList.Add(n);

            if(n.pos == destination)
            {
                result = true;
                break;
            }

            cnt++;

            if(cnt > 1000)
            {
                Debug.Log("while 너무 많이 돌아감");
                break;
            }
        }

        if(result)
        {
            routePath.Clear();
            Node last = closeList[closeList.Count - 1];
            while(last._parent != null)
            {
                routePath.Add(last.pos);
                last = last._parent;
            }

            routePath.Reverse();
        }

        return result;
    }

    private void FindOpenList(Node _n)
    {
        for(int y = -1; y <= 1; y++)
        {
            for(int x = -1; x <= 1; x++)
            {
                if (x == 0 && y == 0) continue;
                
                Vector3Int nextPos = _n.pos + new Vector3Int(x, y, 0);

                Node temp = closeList.Find(x => x.pos == nextPos);
                if (temp != null) continue;

                //타일에서 진짜 갈 수 있는 곳인지
                if(MapManager.Instance.CanMove(nextPos))
                {
                    float g = (_n.pos - nextPos).magnitude + _n.G;

                    Node nextOpenNode = new Node
                    {
                        pos = nextPos,
                        _parent = _n,
                        G = g,
                        F = g + CalcH(nextPos)
                    };

                    Node exist = openList.Contains(nextOpenNode);

                    if(exist != null)
                    {
                        if(nextOpenNode.G < exist.G)
                        {
                            exist.G = nextOpenNode.G;
                            exist.F = nextOpenNode.F;
                            exist._parent = nextOpenNode._parent;

                        }
                    }
                    else
                    {
                        openList.Push(nextOpenNode);
                    }
                }
            }
        }
    }

    private float CalcH(Vector3Int pos)
    {
        Vector3Int distance = destination - pos;
        return distance.magnitude;
    }
    #endregion
}
