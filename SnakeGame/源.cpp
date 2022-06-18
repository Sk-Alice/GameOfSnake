#include <iostream>
#include <graphics.h>       // 图形库插件
#include <conio.h>          // 按键交互, _getch()
#include <time.h>           // 随机函数 srand()和rand()         
#include <windows.h>        // 控制蛇的速度 Sleep()

using namespace std;

// 数据设计

// 坐标属性
typedef struct Point
{
    int x;
    int y;
}MYPOINT;
// 蛇的属性
struct Snake
{
    MYPOINT xy[100];        // 存储蛇的节数的坐标，表示蛇的最长长度100
    int num;                // 蛇的长度(节数)
    char position;          // 方向
}snake;
// 食物属性
struct Food
{
    MYPOINT xy;
    int flag;                // 标记食物是否存在
    int grade;               // 分数
}food;

// 窗口句柄 (弹出的窗口)
HWND hwnd = NULL;
// 把方向枚举出来
enum position { _up, _down, _left, _right };

// 步骤分析
void Init_snake();           // 初始化蛇
void Draw_snake();           // 画蛇
void Move_snake();           // 移动蛇
void Key_down();             // 按键控制蛇的移动
void Init_food();            // 初始化食物
void Draw_food();            // 画食物
void Eat_food();             // 吃食物
void Show_grade();           // 显示分数
int Snake_die();             // 游戏结束,死亡

int main()
{
    // 绘制窗口
    hwnd = initgraph(800, 600); // 窗口大小
    setbkcolor(WHITE);          // 窗口背景颜色
    cleardevice();              // 刷新窗口
    Init_snake();               // 初始化蛇

    while (1)
    {
        cleardevice();          // 刷新窗口
        Draw_snake();           // 画蛇
        Move_snake();           // 移动蛇

        Draw_food();            // 画食物
        Eat_food();             // 吃食物
        Show_grade();           // 显示分数

        if (Snake_die())        // 如果死亡，跳出循环
        {
            break;
        }
        if (food.flag == 0)     // 如果食物不存在，产生食物
        {
            Init_food();        // 初始化食物
        }
        if (_kbhit())           // 判断按键是否按下
        {
            Key_down();         // 按键控制蛇的移动方向
        }

        Sleep(100);             // 控制蛇的速度
    }

    // 接收按键退出
    int temp = _getch();        // 防止结束后窗口闪退
    closegraph();               // 关闭窗口

    return 0;
}

void Init_snake()           // 初始化蛇的前三节
{
    snake.xy[2].x = 0;
    snake.xy[2].y = 0;

    snake.xy[1].x = 10;
    snake.xy[1].y = 0;

    snake.xy[0].x = 20;
    snake.xy[0].y = 0;

    snake.num = 3;
    snake.position = _right;
}

void Draw_snake()            // 画蛇
{
    for (int i = 0; i < snake.num; i++)
    {
        setlinecolor(BLACK);    // 边框颜色
        setfillcolor(GREEN);    // 蛇的颜色
        fillrectangle(snake.xy[i].x, snake.xy[i].y, snake.xy[i].x + 10, snake.xy[i].y + 10);     // 画填充矩形代表蛇
    }
}

void Move_snake()            // 移动蛇
{
    // 蛇身移动原理-交换
    for (int i = snake.num - 1; i > 0; i--)     //从蛇尾开始,蛇的身体往前移动
    {
        snake.xy[i].x = snake.xy[i - 1].x;
        snake.xy[i].y = snake.xy[i - 1].y;
    }
    // 蛇头的移动
    switch (snake.position)
    {
    case _up:
        snake.xy[0].y -= 10;
        break;
    case _down:
        snake.xy[0].y += 10;
        break;
    case _left:
        snake.xy[0].x -= 10;
        break;
    case _right:
        snake.xy[0].x += 10;
        break;
    default:
        break;
    }
}

void Key_down()              // 按键控制蛇的移动
{
    char key = _getch();
    if (key == 32)           // 空格为32,暂停
    {
        MessageBox(hwnd, "暂停", "暂停", 0);
        while (_getch() != 32);
    }

    switch (key)
    {
        // 数字为小键盘
    case 'w':
    case 'W':
    case 72:
        if (snake.position != _down) {
            snake.position = _up;
        }
        break;
    case 's':
    case 'S':
    case 80:
        if (snake.position != _up) {
            snake.position = _down;
        }
        break;
    case 'a':
    case 'A':
    case 75:
        if (snake.position != _right) {
            snake.position = _left;
        }
        break;
    case 'd':
    case 'D':
    case 77:
        if (snake.position != _left) {
            snake.position = _right;
        }
        break;
    }
}

void Init_food()             // 初始化食物
{
    srand((unsigned int)time(NULL));     // 随机函数种子
    food.xy.x = rand() % 80 * 10;        // 后面 %80*10 表示窗口大小
    food.xy.y = rand() % 60 * 10;
    food.flag = 1;                       // 表示食物存在

    for (int i = 0; i < snake.num; i++)
    {
        // 判断食物是否在蛇的身上
        if (food.xy.x == snake.xy[i].x && food.xy.y == snake.xy[i].y)
        {
            // 如果蛇的在身上, 重新产生
            food.xy.x = rand() % 80 * 10;
            food.xy.y = rand() % 60 * 10;
        }
    }
}

void Draw_food()             // 画食物
{
    setlinecolor(BLACK);     // 边框颜色
    setfillcolor(RED);       // 食物为红色
    fillrectangle(food.xy.x, food.xy.y, food.xy.x + 10, food.xy.y + 10);    // 填充矩形代表食物
}

void Eat_food()              // 吃食物
{
    // 当蛇头与食物碰撞
    if (snake.xy[0].x == food.xy.x && snake.xy[0].y == food.xy.y)
    {
        food.flag = 0;
        snake.num++;
        food.grade += 10;
    }
}

void Show_grade()            // 显示分数
{
    char grade[100] = "";
    sprintf_s(grade, "分数：%d", food.grade);   // 把数据写入字符串中
    setbkmode(TRANSPARENT);                    // 设置透明颜色字体
    settextcolor(LIGHTBLUE);                   // 设置为浅蓝色
    outtextxy(650, 30, grade);                 // 在相应位置显示
}

int Snake_die()              // 游戏结束,死亡
{
    // 撞墙
    if (snake.xy[0].x < 0 || snake.xy[0].x > 800 || snake.xy[0].y < 0 || snake.xy[0].y > 600)
    {
        MessageBox(hwnd, "撞墙，游戏结束！", "撞墙警告", 0); // 弹出窗口
        return 1;
    }
    // 自己撞自己
    for (int i = 1; i < snake.num; i++)
    {
        if (snake.xy[0].x == snake.xy[i].x && snake.xy[0].y == snake.xy[i].y)
        {
            MessageBox(hwnd, "自杀，游戏结束！", "自杀警告", 0);
            return 1;
        }
    }
    return 0;
}