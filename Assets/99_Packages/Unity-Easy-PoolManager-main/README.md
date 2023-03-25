# Unity Easy PoolManager
매우 쉬운 풀매니저
## 사용법
### 설명
풀하고 싶은 오브젝트를 Resources\Prefabs 폴더안에 넣어놔야함

![image](https://user-images.githubusercontent.com/64355834/126892204-972d5dc3-5b07-4d2d-b9ca-4d8c274f2f09.png)

IPoolable 인터페이스는 풀매니저로 가져온후 함수를 호출하고싶을때 사용합니다. (없어도됨) Cube.cs 참고
```c#
    public void OnPool()
    {
        transform.position = new Vector3(0, 5, 0); // 0,5,0 좌표로 이동
    }
```
### 생성
```c#
PoolManager.CreatePool<타입>(폴더안에있는 오브젝트이름, 부모 오브젝트 트랜즈폼, 생성 개수); // 풀 생성
```
### 가져오기
```c#
PoolManager.GetItem<타입>(폴더안에있는 오브젝트이름);
```
